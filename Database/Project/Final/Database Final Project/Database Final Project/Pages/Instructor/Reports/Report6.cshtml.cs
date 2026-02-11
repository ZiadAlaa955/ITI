using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Database_Final_Project.Pages.Instructor.Reports
{
    public class Report6Model : PageModel
    {
        public IActionResult OnGet()
        {
            // Security Check: Ensure Instructor is logged in
            if (HttpContext.Session.GetInt32("InstructorId") == null)
            {
                return RedirectToPage("/Instructor/login");
            }
            return Page();
        }

        public IActionResult OnPost(int examId, int studentId)
        {
            // Redirect to the View page passing both the Exam ID and Student ID
            return RedirectToPage("./ViewReport6", new { examId = examId, studentId = studentId });
        }
    }
}