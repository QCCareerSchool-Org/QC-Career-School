// <copyright file="Province.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace CRM.Entities;

public class Province
{
    public uint Id { get; set; }

    public uint CountryId { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public Country Country { get; set; }
}
