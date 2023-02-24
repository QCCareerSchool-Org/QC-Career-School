// <copyright file="Currency.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace CRM.Entities;

public class Currency
{
    public uint Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string Symbol { get; set; }
}
