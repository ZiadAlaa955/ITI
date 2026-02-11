using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Database_Final_Project.Models;

namespace Database_Final_Project.Pages.Instructor
{
    public class GenerateExamModel : PageModel
    {
        private readonly DbProjectContext _context;
        public GenerateExamModel(DbProjectContext context) => _context = context;

        [BindProperty(SupportsGet = true)]
        public string CourseName { get; set; } = "";

        public string? ErrorMessage { get; set; }

        public IActionResult OnGet(string course)
        {
            if (HttpContext.Session.GetInt32("InstructorId") == null)
                return RedirectToPage("/Instructor/login");

            if (string.IsNullOrEmpty(course))
                return RedirectToPage("./InstructorDashboard");

            CourseName = course;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int duration, int mcqs, int tfs)
        {
            var conn = _context.Database.GetDbConnection();
            int newExamId = 0;

            try
            {
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "Generate_Exam";
                    command.CommandType = CommandType.StoredProcedure;

                    // Input Parameters
                    command.Parameters.Add(new SqlParameter("@CrsName", CourseName));
                    command.Parameters.Add(new SqlParameter("@ExamDuration", duration));
                    command.Parameters.Add(new SqlParameter("@NoOfMCQs", mcqs));
                    command.Parameters.Add(new SqlParameter("@NoOfTFs", tfs));

                    // Output Parameter
                    var outParam = new SqlParameter("@ExamID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    command.Parameters.Add(outParam);

                    if (conn.State != ConnectionState.Open) await conn.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            await reader.ReadAsync();
                            // Check the column name "ErrorMessage"
                            if (reader.GetName(0) == "ErrorMessage")
                            {
                                string msg = reader.GetString(0);
                                if (!string.IsNullOrEmpty(msg))
                                {
                                    ErrorMessage = msg;
                                    return Page(); // Stop here and show error
                                }
                            }
                        }
                    }

                    // If we reach here, validation passed. Get the Output ID.
                    if (outParam.Value != DBNull.Value)
                    {
                        newExamId = (int)outParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "System Error: " + ex.Message;
                return Page();
            }

            // Redirect to the Exam Report (Report 5)
            return RedirectToPage("/Instructor/Reports/ViewReport5", new { id = newExamId });
        }
    }
}