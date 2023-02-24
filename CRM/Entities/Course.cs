// <copyright file="Course.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace CRM.Entities;

public class Course
{
    public uint Id { get; set; }

    public uint SchoolId { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string Prefix { get; set; }

    public School School { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }
}
