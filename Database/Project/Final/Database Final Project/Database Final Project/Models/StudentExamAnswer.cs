using System;
using System.Collections.Generic;

namespace Database_Final_Project.Models;

public partial class StudentExamAnswer
{
    public int StudentId { get; set; }

    public int ExamId { get; set; }

    public int QId { get; set; }

    public int Grade { get; set; }

    public string StudAnswer { get; set; } = null!;

    public virtual Exam Exam { get; set; } = null!;

    public virtual Question QIdNavigation { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
