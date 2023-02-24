// <copyright file="Course.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace SC.Entities;

public class Course
{
    public uint Id { get; set; }

    public uint SchoolId { get; set; }

    public string Code { get; set; }

    public ushort Version { get; set; }

    public string StudentTypeType { get; set; }

    public string Name { get; set; }

    public bool CourseGuide { get; set; }

    public bool QuizzesEnabled { get; set; }

    public bool NoTutor { get; set; }

    public byte UnitType { get; set; }

    public bool Enabled { get; set; }

    public sbyte Order { get; set; }

    public bool UnitsEnabled { get; set; }

    public int EntityVersion { get; set; }

    public School School { get; set; }

    public StudentType StudentType { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }
}
