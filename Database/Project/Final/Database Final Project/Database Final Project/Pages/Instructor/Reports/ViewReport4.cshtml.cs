using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using Database_Final_Project.Models;

namespace Database_Final_Project.Pages.Instructor.Reports
{
    public class ViewReport4Model : PageModel
    {
        private readonly DbProjectContext _context;
        public ViewReport4Model(DbProjectContext context) => _context = context;

        public string CourseName { get; set; } = "";
        public string? ErrorMessage { get; set; }
        public List<Database_Final_Project.Models.Topic> Topics { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (HttpContext.Session.GetInt32("InstructorId") == null)
                return RedirectToPage("/Instructor/login");

            var conn = _context.Database.GetDbConnection();

            try
            {
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "Report_get_Course_Topics";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@courseID", id));

                    if (conn.State != ConnectionState.Open) await conn.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            // 1. Validation Check
                            if (reader.GetName(0) == "ErrorMessage")
                            {
                                await reader.ReadAsync();
                                ErrorMessage = reader.GetString(0);
                                return Page();
                            }

                            // 2. Map to Topic Model
                            while (await reader.ReadAsync())
                            {
                                Topics.Add(new Database_Final_Project.Models.Topic
                                {
                                    // Mapping Course_ID and Topic_Name from your SP
                                    CourseId = reader.GetInt32(reader.GetOrdinal("Course_ID")),
                                    TopicName = reader.GetString(reader.GetOrdinal("Topic_Name"))
                                });
                            }
                        }
                    }
                }

                // Fetch course name for the header if validation passed
                var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == id);
                CourseName = course?.CourseName ?? $"Course #{id}";
            }
            catch (Exception ex)
            {
                ErrorMessage = "Database Error: " + ex.Message;
            }

            return Page();
        }
    }
}