using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Database_Final_Project.Pages.Instructor.Reports
{
    public class Report1Model : PageModel
    {
        public void OnGet() { }

        public IActionResult OnPost(int trackId)
        {
            // Carrying the TrackID to the specific ViewReport1 page
            return RedirectToPage("./ViewReport1", new { id = trackId });
        }
    }
}