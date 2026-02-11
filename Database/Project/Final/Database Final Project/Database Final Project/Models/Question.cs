using System;
using System.Collections.Generic;

namespace Database_Final_Project.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public string QDescription { get; set; } = null!;

    public string QType { get; set; } = null!;

    public string ModelAnswer { get; set; } = null!;

    public int Mark { get; set; }

    public int? CrsId { get; set; }

    public virtual Course? Crs { get; set; }

    public virtual ICollection<QuestionAnswerOption> QuestionAnswerOptions { get; set; } = new List<QuestionAnswerOption>();

    public virtual ICollection<StudentExamAnswer> StudentExamAnswers { get; set; } = new List<StudentExamAnswer>();

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
}
