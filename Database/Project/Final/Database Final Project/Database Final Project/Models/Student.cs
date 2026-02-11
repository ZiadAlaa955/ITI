using System;
using System.Collections.Generic;

namespace Database_Final_Project.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Street { get; set; }

    public int? TrackId { get; set; }

    public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    public virtual ICollection<StudentExamAnswer> StudentExamAnswers { get; set; } = new List<StudentExamAnswer>();

    public virtual Track? Track { get; set; }
}
