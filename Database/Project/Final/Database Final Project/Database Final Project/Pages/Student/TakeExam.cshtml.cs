using System.Data;
using Database_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Database_Final_Project.Pages.Student
{
    public class TakeExamModel : PageModel
    {
        private readonly DbProjectContext _context;
        public TakeExamModel(DbProjectContext context) => _context = context;

        public List<QuestionViewModel> Questions { get; set; } = new();
        public string? ErrorMessage { get; set; }
        public int ExamId { get; set; }
        public int Duration { get; set; }

        public async Task<IActionResult> OnGetAsync(int courseId)
        {
            if (HttpContext.Session.GetInt32("StudentId") == null)
                return RedirectToPage("/Student/Login");

            var conn = _context.Database.GetDbConnection();
            try
            {
                if (conn.State != ConnectionState.Open) await conn.OpenAsync();

                // 1. Get Random Exam ID
                using (var cmd1 = conn.CreateCommand())
                {
                    cmd1.CommandText = "Get_Random_Exam_ID_By_Course";
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add(new SqlParameter("@CourseID", courseId));
                    using var reader = await cmd1.ExecuteReaderAsync();
                    if (await reader.ReadAsync())
                    {
                        if (reader.HasColumn("ErrorMessage") && !string.IsNullOrEmpty(reader["ErrorMessage"].ToString()))
                        {
                            ErrorMessage = reader["ErrorMessage"].ToString();
                            return Page();
                        }
                        ExamId = Convert.ToInt32(reader["Exam_ID"]);
                    }
                }

                // 2. Load Questions (No ID available, using Description)
                using (var cmd2 = conn.CreateCommand())
                {
                    cmd2.CommandText = "Report_Get_Exam_Questions";
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("@ExamID", ExamId));
                    using var reader = await cmd2.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        Questions.Add(new QuestionViewModel
                        {
                            QDescription = reader.GetString(0),
                            QType = reader.GetString(1),
                            Mark = reader.GetInt32(2),
                            Options = reader.IsDBNull(3) ? "" : reader.GetString(3)
                        });
                    }
                }
                Duration = 30; // Fallback duration
            }
            catch (Exception ex) { ErrorMessage = ex.Message; }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormCollection form)
        {
            int studentId = HttpContext.Session.GetInt32("StudentId") ?? 0;

            if (!int.TryParse(form["ExamId"], out int eId))
            {
                ErrorMessage = "Invalid Exam ID.";
                return Page();
            }

            var conn = _context.Database.GetDbConnection();

            try
            {
                if (conn.State != ConnectionState.Open) await conn.OpenAsync();
                using (var trans = await conn.BeginTransactionAsync())
                {

                    // Loop through answers starting with "q_"
                    foreach (var key in form.Keys.Where(k => k.StartsWith("q_")))
                    {
                        string qDesc = key.Substring(2); // Extracts the text after "q_"
                        string ans = form[key].ToString();

                        using var cmd = conn.CreateCommand();
                        cmd.Transaction = trans;

                        // Using your exact database column name: Q_Description
                        cmd.CommandText = @"
                    DECLARE @ActualID int;
                    SELECT TOP 1 @ActualID = Question_ID FROM Question WHERE Q_Description = @desc;
                    
                    IF @ActualID IS NOT NULL
                    BEGIN
                        EXEC Submit_Exam_Answers @studentID, @examID, @ActualID, @studentAnswer;
                    END";

                        cmd.Parameters.Add(new SqlParameter("@studentID", studentId));
                        cmd.Parameters.Add(new SqlParameter("@examID", eId));
                        cmd.Parameters.Add(new SqlParameter("@desc", qDesc));
                        cmd.Parameters.Add(new SqlParameter("@studentAnswer", ans));
                        await cmd.ExecuteNonQueryAsync();
                    }

                    // 2. Run your Correct_Exam SP
                    int score = 0;
                    using (var cmdCorr = conn.CreateCommand())
                    {
                        cmdCorr.Transaction = trans;
                        cmdCorr.CommandText = "Correct_Exam";
                        cmdCorr.CommandType = CommandType.StoredProcedure;
                        cmdCorr.Parameters.Add(new SqlParameter("@studentID", studentId));
                        cmdCorr.Parameters.Add(new SqlParameter("@examID", eId));
                        var res = await cmdCorr.ExecuteScalarAsync();
                        score = (res != null && res != DBNull.Value) ? Convert.ToInt32(res) : 0;
                    }

                    // 3. Get Total Marks for the fraction display
                    int total = 0;
                    using (var cmdT = conn.CreateCommand())
                    {
                        cmdT.Transaction = trans;
                        cmdT.CommandText = "SELECT SUM(q.Mark) FROM Exam_Question eq JOIN Question q ON eq.Question_ID = q.Question_ID WHERE eq.Exam_ID = @eId";
                        cmdT.Parameters.Add(new SqlParameter("@eId", eId));
                        var totalRes = await cmdT.ExecuteScalarAsync();
                        total = (totalRes != null && totalRes != DBNull.Value) ? Convert.ToInt32(totalRes) : 0;
                    }

                    await trans.CommitAsync();
                    return RedirectToPage("/Student/ExamResult", new { score, total });
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Submission Error: " + ex.Message;
                return Page();
            }
        }

        public class QuestionViewModel
        {
            // Match these to your Question class properties
            public string QDescription { get; set; } = "";
            public string QType { get; set; } = "";
            public int Mark { get; set; }
            public string Options { get; set; } = "";
        }
    }

    // Helper to check column existence safely
    public static class DbExtensions
    {
        public static bool HasColumn(this IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase)) return true;
            }
            return false;
        }
    }
}