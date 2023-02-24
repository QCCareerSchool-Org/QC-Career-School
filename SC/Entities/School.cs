// <copyright file="School.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace SC.Entities;

public class School
{
    public uint Id { get; set; }

    public string Name { get; set; }

    public ICollection<Course> Courses { get; set; }
}
