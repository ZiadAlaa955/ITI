using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using Database_Final_Project.Models;

namespace Database_Final_Project.Pages.Instructor.Reports
{
    public class ViewReport2Model : PageModel
    {
        private readonly Database_Final_Project.Models.DbProjectContext _context;

        public ViewReport2Model(Database_Final_Project.Models.DbProjectContext context)
        {
            _context = context;
        }

        public string? ErrorMessage { get; set; }
        public string StudentName { get; set; } = "";
        public int StudentId { get; set; }
        public DataTable GradesTable { get; set; } = new DataTable();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (HttpContext.Session.GetInt32("InstructorId") == null)
            {
                return RedirectToPage("/Instructor/login");
            }

            StudentId = id;
            var connection = _context.Database.GetDbConnection();

            try
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "Report_Get_Student_Grades";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@StudentID", id));

                    if (connection.State != ConnectionState.Open) await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            // Check for validation error column
                            if (reader.GetName(0) == "ErrorMessage")
                            {
                                await reader.ReadAsync();
                                ErrorMessage = reader.GetString(0);
                                return Page();
                            }

                            // Load result set into the DataTable
                            GradesTable.Load(reader);
                        }
                    }
                }

                // Fetch student name for the header if validation passed
                var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id);
                StudentName = student?.StudentName ?? "Student Transcript";
            }
            catch (Exception ex)
            {
                ErrorMessage = "Database Error: " + ex.Message;
            }

            return Page();
        }
    }
}