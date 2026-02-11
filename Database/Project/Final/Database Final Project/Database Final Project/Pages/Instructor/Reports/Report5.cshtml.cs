using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Database_Final_Project.Pages.Instructor.Reports
{
    public class Report5Model : PageModel
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

        public IActionResult OnPost(int examId)
        {
            // Carry the Exam ID to the Preview page
            return RedirectToPage("./ViewReport5", new { id = examId });
        }
    }
}