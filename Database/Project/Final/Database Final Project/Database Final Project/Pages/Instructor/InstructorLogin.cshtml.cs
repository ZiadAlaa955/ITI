using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Database_Final_Project.Models;

namespace Database_Final_Project.Pages.Instructor
{
    public class LoginModel : PageModel
    {
        private readonly DbProjectContext _context;
        public LoginModel(DbProjectContext context) => _context = context;

        // Matches student-style error property
        public string ErrorMessage { get; set; } = string.Empty;

        public void OnGet()
        {
            // Reset session on visit
            HttpContext.Session.Clear();
        }

        public async Task<IActionResult> OnPostAsync(string instructorName)
        {
            if (string.IsNullOrEmpty(instructorName))
            {
                ErrorMessage = "Please enter your name.";
                return Page();
            }

            // Query using the model property InsName
            var instructor = await _context.Instructors
                .FirstOrDefaultAsync(i => i.InsName == instructorName);

            if (instructor != null)
            {
                // Updated Session keys for consistency
                HttpContext.Session.SetInt32("InstructorId", instructor.InsId);
                HttpContext.Session.SetString("InstructorName", instructor.InsName);

                // Redirect to the newly renamed dashboard path
                return RedirectToPage("/Instructor/InstructorDashboard");
            }

            ErrorMessage = "Instructor name not found. Please try again.";
            return Page();
        }
    }
}