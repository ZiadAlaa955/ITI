using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Database_Final_Project.Models;

namespace Database_Final_Project.Pages.Exams
{
    public class TakeModel : PageModel
    {
        private readonly DbProjectContext _context;
        public TakeModel(DbProjectContext context) => _context = context;

        // Allow null because FirstOrDefaultAsync may return null.
        public Exam? CurrentExam { get; set; }
        public List<Question> Questions { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int crsId)
        {
            // 1. Find the exam for the course
            // 2. .Include(e => e.Questions) tells EF to look into the Exam_Question table for you
            CurrentExam = await _context.Exams
                .Include(e => e.Questions)
                    .ThenInclude(q => q.QuestionAnswerOptions)
                .FirstOrDefaultAsync(e => e.CrsId == crsId);

            if (CurrentExam == null) return RedirectToPage("/Index");

            // This property 'Questions' is the link to your Exam_Question table!
            Questions = CurrentExam.Questions.ToList();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int examId, Dictionary<int, string> answers)
        {
            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null) return RedirectToPage("/Login");

            // Fetch the questions again to verify the correct ModelAnswer
            var examQuestions = await _context.Questions
                .Where(q => answers.Keys.Contains(q.QuestionId))
                .ToListAsync();

            foreach (var item in answers)
            {
                var question = examQuestions.FirstOrDefault(q => q.QuestionId == item.Key);

                // Compare StudAnswer to ModelAnswer to calculate Grade
                int calculatedGrade = 0;
                if (question != null && question.ModelAnswer == item.Value)
                {
                    calculatedGrade = question.Mark;
                }

                var response = new StudentExamAnswer
                {
                    StudentId = studentId.Value,
                    ExamId = examId,
                    QId = item.Key,
                    StudAnswer = item.Value,
                    Grade = calculatedGrade // Automatically graded!
                };
                _context.StudentExamAnswers.Add(response);
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}