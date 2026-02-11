using Database_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Database_Final_Project.Pages.Student
{
    public class StudentDashboardModel : PageModel
    {
        private readonly DbProjectContext _context;
        public StudentDashboardModel(DbProjectContext context) => _context = context;

        // FIXED: Using full path to avoid namespace conflict
        public Models.Student CurrentStudent { get; set; } = default!;
        public List<Models.Course> EnrolledCourses { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            var studentId = HttpContext.Session.GetInt32("StudentId");

            // Note: If Login.cshtml is in the ROOT Pages folder, keep "/Login"
            if (studentId == null) return RedirectToPage("/Login");

            var student = await _context.Students
                .Include(s => s.Track)
                .FirstOrDefaultAsync(m => m.StudentId == studentId.Value);

            if (student == null)
            {
                HttpContext.Session.Remove("StudentId");
                return RedirectToPage("/Login");
            }

            CurrentStudent = student;

            EnrolledCourses = await _context.StudentCourses
                .Where(sc => sc.StudentId == studentId.Value)
                .Select(sc => sc.Crs)
                .ToListAsync();

            return Page();
        }
    }
}