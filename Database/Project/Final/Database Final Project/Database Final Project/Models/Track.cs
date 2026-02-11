using System;
using System.Collections.Generic;

namespace Database_Final_Project.Models;

public partial class Track
{
    public int TrackId { get; set; }

    public string TrackName { get; set; } = null!;

    public int? MaxNoStudents { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
