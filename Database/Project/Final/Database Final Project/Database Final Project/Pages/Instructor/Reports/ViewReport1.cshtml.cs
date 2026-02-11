using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using Database_Final_Project.Models;

namespace Database_Final_Project.Pages.Instructor.Reports
{
    public class ViewReport1Model : PageModel
    {
        private readonly Database_Final_Project.Models.DbProjectContext _context;
        public ViewReport1Model(Database_Final_Project.Models.DbProjectContext context) => _context = context;

        public List<Database_Final_Project.Models.Student> Students { get; set; } = new();
        public string? ErrorMessage { get; set; } // <--- This must exist!
        public string TrackName { get; set; } = "N/A";

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (HttpContext.Session.GetInt32("InstructorId") == null)
                return RedirectToPage("/Instructor/login");

            var conn = _context.Database.GetDbConnection();
            try
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Report_Get_Students_By_Track";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@TrackID", id));
                    if (conn.State != ConnectionState.Open) await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.GetName(0) == "ErrorMessage")
                            {
                                await reader.ReadAsync();
                                ErrorMessage = reader.GetString(0);
                                return Page();
                            }
                            while (await reader.ReadAsync())
                            {
                                Students.Add(new Database_Final_Project.Models.Student
                                {
                                    StudentId = reader.GetInt32(reader.GetOrdinal("Student_ID")),
                                    StudentName = reader.GetString(reader.GetOrdinal("Student_Name")),
                                    PhoneNumber = reader.GetString(reader.GetOrdinal("Phone_Number")),
                                    City = reader.GetString(reader.GetOrdinal("City")),
                                    Street = reader.IsDBNull(reader.GetOrdinal("Street")) ? null : reader.GetString(reader.GetOrdinal("Street"))
                                });
                            }
                        }
                    }
                }
                var track = await _context.Tracks.FindAsync(id);
                if (track != null) TrackName = track.TrackName;
            }
            catch (Exception ex) { ErrorMessage = ex.Message; }
            return Page();
        }
    }
}