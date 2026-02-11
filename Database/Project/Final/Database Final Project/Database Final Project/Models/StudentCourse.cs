using System;
using System.Collections.Generic;

namespace Database_Final_Project.Models;

public partial class StudentCourse
{
    public int StudentId { get; set; }

    public int CrsId { get; set; }

    public double? Grade { get; set; }

    public virtual Course Crs { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
