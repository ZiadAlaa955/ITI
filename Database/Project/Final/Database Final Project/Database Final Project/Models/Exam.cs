using System;
using System.Collections.Generic;

namespace Database_Final_Project.Models;

public partial class Exam
{
    public int ExamId { get; set; }

    public int ExamDurationMins { get; set; }

    public int? CrsId { get; set; }

    public virtual Course? Crs { get; set; }

    public virtual ICollection<StudentExamAnswer> StudentExamAnswers { get; set; } = new List<StudentExamAnswer>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
