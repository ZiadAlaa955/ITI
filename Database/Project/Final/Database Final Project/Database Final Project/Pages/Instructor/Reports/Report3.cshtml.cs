using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Database_Final_Project.Pages.Instructor.Reports
{
    public class Report3Model : PageModel
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

        public IActionResult OnPost(int instructorId)
        {
            // Carry the Instructor ID to the Preview page
            return RedirectToPage("./ViewReport3", new { id = instructorId });
        }
    }
}