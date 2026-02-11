using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using Database_Final_Project.Models;

namespace Database_Final_Project.Pages.Instructor.Reports
{
    public class ViewReport6Model : PageModel
    {
        private readonly DbProjectContext _context;
        public ViewReport6Model(DbProjectContext context) => _context = context;

        public class AnswerReviewRow
        {
            public string Question { get; set; } = "";
            public string StudentAnswer { get; set; } = "";
            public string ModelAnswer { get; set; } = "";
            public int EarnedGrade { get; set; }
            public int MaxMark { get; set; }
        }

        public List<AnswerReviewRow> Results { get; set; } = new();
        public string StudentName { get; set; } = "";
        public string? ErrorMessage { get; set; }
        public Database_Final_Project.Models.Exam? ExamInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int examId, int studentId)
        {
            if (HttpContext.Session.GetInt32("InstructorId") == null)
                return RedirectToPage("/Instructor/login");

            var conn = _context.Database.GetDbConnection();

            try
            {
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "Report_Get_Students_Exam_Answers";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ExamID", examId));
                    command.Parameters.Add(new SqlParameter("@StudentID", studentId));

                    if (conn.State != ConnectionState.Open) await conn.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            // 1. Validation Check (Catches all 3 IF blocks in your SP)
                            if (reader.GetName(0) == "ErrorMessage")
                            {
                                await reader.ReadAsync();
                                ErrorMessage = reader.GetString(0);
                                return Page();
                            }

                            // 2. Data Mapping
                            while (await reader.ReadAsync())
                            {
                                Results.Add(new AnswerReviewRow
                                {
                                    Question = reader.GetString(reader.GetOrdinal("Q_Description")),
                                    StudentAnswer = reader.IsDBNull(reader.GetOrdinal("Stud_Answer")) ? "No Answer" : reader.GetString(reader.GetOrdinal("Stud_Answer")),
                                    ModelAnswer = reader.GetString(reader.GetOrdinal("Model_Answer")),
                                    EarnedGrade = reader.IsDBNull(reader.GetOrdinal("Grade")) ? 0 : reader.GetInt32(reader.GetOrdinal("Grade")),
                                    MaxMark = reader.GetInt32(reader.GetOrdinal("Mark"))
                                });
                            }
                        }
                    }
                }

                // Metadata for the UI header
                var student = await _context.Students.FindAsync(studentId);
                StudentName = student?.StudentName ?? "Unknown Student";

                ExamInfo = await _context.Exams
                    .Include(e => e.Crs)
                    .FirstOrDefaultAsync(e => e.ExamId == examId);
            }
            catch (Exception ex)
            {
                ErrorMessage = "Database Error: " + ex.Message;
            }

            return Page();
        }
    }
}