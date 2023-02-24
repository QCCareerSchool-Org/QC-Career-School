// <copyright file="Student.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace CRM.Entities;

public class Student
{
    public uint Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public string City { get; set; }

    public uint? ProvinceId { get; set; }

    public string? PostalCode { get; set; }

    public uint CountryId { get; set; }

    public ushort TelephoneCountryCode { get; set; }

    public string? TelephoneNumber { get; set; }

    public string? EmailAddress { get; set; }

    public Province? Province { get; set; }

    public Country Country { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }
}
