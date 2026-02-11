using System;
using System.Collections.Generic;

namespace Database_Final_Project.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public int? TrackId { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();

    public virtual Track? Track { get; set; }

    public virtual ICollection<Instructor> Ins { get; set; } = new List<Instructor>();
}
