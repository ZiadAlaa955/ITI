using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Database_Final_Project.Pages.Instructor.Reports
{
    public class Report4Model : PageModel
    {
        public IActionResult OnPost(int courseId)
        {
            return RedirectToPage("./ViewReport4", new { id = courseId });
        }
    }
}