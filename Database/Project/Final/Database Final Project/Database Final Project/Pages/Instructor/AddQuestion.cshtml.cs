using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Database_Final_Project.Models;

namespace Database_Final_Project.Pages.Instructor
{
    public class AddQuestionModel : PageModel
    {
        private readonly DbProjectContext _context;
        public AddQuestionModel(DbProjectContext context) => _context = context;

        [BindProperty(SupportsGet = true)]
        public int CourseId { get; set; }

        [BindProperty] public string Description { get; set; } = "";
        [BindProperty] public string QType { get; set; } = "MCQ";
        [BindProperty] public string ModelAnswer { get; set; } = "";
        [BindProperty] public int Mark { get; set; } = 5;
        [BindProperty] public string RawOptions { get; set; } = "";

        public string? ErrorMessage { get; set; }
        public string? SuccessMessage { get; set; }

        public IActionResult OnGet(int courseId)
        {
            if (HttpContext.Session.GetInt32("InstructorId") == null)
                return RedirectToPage("/Instructor/login");

            CourseId = courseId;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var conn = _context.Database.GetDbConnection();
            try
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Insert_Question";
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Input Parameters
                    cmd.Parameters.Add(new SqlParameter("@QDesc", Description));
                    cmd.Parameters.Add(new SqlParameter("@QType", QType));
                    cmd.Parameters.Add(new SqlParameter("@Model_Answer", ModelAnswer));
                    cmd.Parameters.Add(new SqlParameter("@Mark", Mark));
                    cmd.Parameters.Add(new SqlParameter("@CrsID", CourseId));
                    cmd.Parameters.Add(new SqlParameter("@OptionsList", QType == "MCQ" ? RawOptions : (object)DBNull.Value));

                    // Output Parameter
                    var outParam = new SqlParameter("@QID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(outParam);

                    if (conn.State != ConnectionState.Open) await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            await reader.ReadAsync();
                            string msg = reader.GetString(0);
                            if (!string.IsNullOrEmpty(msg) && msg.StartsWith("Error"))
                            {
                                ErrorMessage = msg;
                                return Page();
                            }
                        }
                    }

                    SuccessMessage = "Question added successfully with ID #" + outParam.Value;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "System Error: " + ex.Message;
            }

            return Page();
        }
    }
}