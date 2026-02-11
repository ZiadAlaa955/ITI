using System;
using System.Collections.Generic;

namespace Database_Final_Project.Models;

public partial class Topic
{
    public string TopicName { get; set; } = null!;

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;
}
