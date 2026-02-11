using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Database_Final_Project.Pages.Instructor.Reports
{
    public class Report2Model : PageModel
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

        public IActionResult OnPost(int studentId)
        {
            // Redirect to the View page with the ID as a route parameter
            return RedirectToPage("./ViewReport2", new { id = studentId });
        }
    }
}