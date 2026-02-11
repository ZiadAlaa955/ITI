using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using Database_Final_Project.Models;

namespace Database_Final_Project.Pages.Instructor.Reports
{
    public class ViewReport5Model : PageModel
    {
        private readonly DbProjectContext _context;

        public ViewReport5Model(DbProjectContext context) => _context = context;

        public class ExamQuestionRow
        {
            public string Description { get; set; } = "";
            public string Type { get; set; } = "";
            public int Mark { get; set; }
            public string Options { get; set; } = "";
        }

        public List<ExamQuestionRow> Questions { get; set; } = new();
        public string? ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (HttpContext.Session.GetInt32("InstructorId") == null)
                return RedirectToPage("/Instructor/login");

            var conn = _context.Database.GetDbConnection();

            try
            {
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "Report_Get_Exam_Questions";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ExamID", id));

                    if (conn.State != ConnectionState.Open) await conn.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            // Validation Check
                            if (reader.GetName(0) == "ErrorMessage")
                            {
                                await reader.ReadAsync();
                                ErrorMessage = reader.GetString(0);
                                return Page();
                            }

                            while (await reader.ReadAsync())
                            {
                                Questions.Add(new ExamQuestionRow
                                {
                                    Description = reader.GetString(reader.GetOrdinal("Q_Description")),
                                    Type = reader.GetString(reader.GetOrdinal("Q_Type")),
                                    Mark = reader.GetInt32(reader.GetOrdinal("Mark")),
                                    Options = reader.IsDBNull(reader.GetOrdinal("Options")) ? "" : reader.GetString(reader.GetOrdinal("Options"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Error: " + ex.Message;
            }

            return Page();
        }
    }
}