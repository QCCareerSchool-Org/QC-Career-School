// <copyright file="Country.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace SC.Entities;

public class Country
{
    public uint Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public ushort ISOName { get; set; }

    public short PriceDisplayOrder { get; set; }

    public ICollection<Province> Provinces { get; set; }
}
