// <copyright file="Country.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace CRM.Entities;

public class Country
{
    public uint Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public ICollection<Province> Provinces { get; set; }
}
