// <copyright file="T2202Receipt.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace SC.Entities;

public class T2202Receipt
{
    public uint Id { get; set; }

    public uint EnrollmentId { get; set; }

    public int StartYear { get; set; }

    public byte StartMonth { get; set; }

    public int EndYear { get; set; }

    public byte EndMonth { get; set; }

    public decimal Tuition { get; set; }

    public string Address1 { get; set; }

    public string? Address2 { get; set; }

    public string City { get; set; }

    public string? PostalCode { get; set; }

    public uint? ProvinceId { get; set; }

    public uint CountryId { get; set; }

    public uint Accessed { get; set; }

    public uint Version { get; set; }
}
