using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Database_Final_Project.Pages.Student
{
    public class ExamResultModel : PageModel
    {
        // SupportsGet = true allows these to be populated automatically from the URL
        // e.g., /Student/ExamResult?score=18&total=20
        [BindProperty(SupportsGet = true)]
        public int Score { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Total { get; set; }

        // We use a property to handle the message logic
        public string FeedbackMessage { get; set; } = "";
        public string StatusClass { get; set; } = "";

        public void OnGet()
        {
            // Simple validation to prevent division by zero
            if (Total <= 0)
            {
                FeedbackMessage = "Unable to calculate grade. Total marks are missing.";
                StatusClass = "warning";
                return;
            }

            // Calculate percentage for feedback logic
            double percentage = ((double)Score / Total) * 100;

            if (percentage >= 85)
            {
                FeedbackMessage = "Excellent work! You've mastered this material.";
                StatusClass = "success";
            }
            else if (percentage >= 50)
            {
                FeedbackMessage = "Great job! You passed the exam.";
                StatusClass = "success";
            }
            else
            {
                FeedbackMessage = "You didn't pass this time. Review the material and try again!";
                StatusClass = "danger";
            }
        }
    }
}