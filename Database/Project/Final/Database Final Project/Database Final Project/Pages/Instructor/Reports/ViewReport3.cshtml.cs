using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Database_Final_Project.Models;

namespace Database_Final_Project.Pages.Instructor.Reports
{
    public class ViewReport3Model : PageModel
    {
        private readonly Database_Final_Project.Models.DbProjectContext _context;
        public ViewReport3Model(Database_Final_Project.Models.DbProjectContext context) => _context = context;

        public string InstructorName { get; set; } = "Unknown Instructor";
        public string? ErrorMessage { get; set; } // Property for validation error
        public List<CourseEnrollment> CourseData { get; set; } = new();

        public struct CourseEnrollment
        {
            public string Name;
            public int StudentCount;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (HttpContext.Session.GetInt32("InstructorId") == null)
                return RedirectToPage("/Instructor/login");

            var conn = _context.Database.GetDbConnection();

            try
            {
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "Report_Get_Instructor_courses_AND_Count";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@instructorID", id));

                    if (conn.State != ConnectionState.Open)
                        await conn.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            // 1. Validation Check for ErrorMessage column
                            if (reader.GetName(0) == "ErrorMessage")
                            {
                                await reader.ReadAsync();
                                ErrorMessage = reader.GetString(0);
                                return Page();
                            }

                            // 2. Data Mapping
                            while (await reader.ReadAsync())
                            {
                                CourseData.Add(new CourseEnrollment
                                {
                                    // Using column names is safer than indexes
                                    Name = reader.GetString(reader.GetOrdinal("Course_Name")),
                                    StudentCount = reader.GetInt32(1) // count(sc.Student_ID) has no name in your SP, so we use index 1
                                });
                            }
                        }
                    }
                }

                // Get Instructor name for the header if validation passed
                var ins = await _context.Instructors.FindAsync(id);
                if (ins != null) InstructorName = ins.InsName;
            }
            catch (Exception ex)
            {
                ErrorMessage = "Database Error: " + ex.Message;
            }

            return Page();
        }
    }
}