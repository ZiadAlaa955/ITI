using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Database_Final_Project.Models;

namespace Database_Final_Project.Pages.Student
{
    public class LoginModel : PageModel
    {
        private readonly DbProjectContext _context;

        public LoginModel(DbProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string StudentName { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        public void OnGet()
        {
            // Clear any old session when they visit the login page
            HttpContext.Session.Clear();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(StudentName))
            {
                ErrorMessage = "Please enter your name.";
                return Page();
            }

            // Search database for the student name
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.StudentName == StudentName);

            if (student != null)
            {
                // Save Student_ID to session for later use in Exams
                HttpContext.Session.SetInt32("StudentId", student.StudentId);
                HttpContext.Session.SetString("StudentName", student.StudentName);

                return RedirectToPage("/Student/StudentDashboard");
            }

            ErrorMessage = "Student name not found. Please try again.";
            return Page();
        }
    }
}