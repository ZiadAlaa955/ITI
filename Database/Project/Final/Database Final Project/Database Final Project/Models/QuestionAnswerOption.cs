using System;
using System.Collections.Generic;

namespace Database_Final_Project.Models;

public partial class QuestionAnswerOption
{
    public int QuestionId { get; set; }

    public string QAnsOption { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
