using System;
using System.Collections.Generic;

namespace Database_Final_Project.Models;

public partial class Instructor
{
    public int InsId { get; set; }

    public string InsName { get; set; } = null!;

    public DateOnly? HiringDate { get; set; }

    public int? TrackId { get; set; }

    public virtual Track? Track { get; set; }

    public virtual ICollection<Course> Crs { get; set; } = new List<Course>();
}
