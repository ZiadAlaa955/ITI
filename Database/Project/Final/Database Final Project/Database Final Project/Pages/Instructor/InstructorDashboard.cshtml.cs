using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Database_Final_Project.Models;

namespace Database_Final_Project.Pages.Instructor
{
    public class InstructorDashboardModel : PageModel
    {
        private readonly DbProjectContext _context;

        public InstructorDashboardModel(DbProjectContext context)
        {
            _context = context;
        }

        // Properties to hold the data for the UI
        public Models.Instructor CurrentInstructor { get; set; } = default!;
        public List<Models.Course> AssignedCourses { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            // 1. Retrieve the Instructor ID from the session (Matches Login logic)
            var instructorId = HttpContext.Session.GetInt32("InstructorId");

            if (instructorId == null)
            {
                // Redirect to login if session is empty
                return RedirectToPage("/Instructor/login");
            }

            // 2. Fetch Instructor details including their Track
            var instructor = await _context.Instructors
                .Include(i => i.Track)
                .FirstOrDefaultAsync(i => i.InsId == instructorId.Value);

            if (instructor == null)
            {
                HttpContext.Session.Clear();
                return RedirectToPage("/Instructor/login");
            }

            CurrentInstructor = instructor;

            // 3. Fetch courses assigned to this specific Instructor
            // Based on your model: Instructor has ICollection<Course> Crs
            // Use .Any() to find courses where this specific instructor is in the Ins collection
            AssignedCourses = await _context.Courses
                .Where(c => c.Ins.Any(i => i.InsId == instructorId.Value))
                .ToListAsync();

            return Page();
        }
    }
}