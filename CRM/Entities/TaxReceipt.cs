// <copyright file="TaxReceipt.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace CRM.Entities;

public class TaxReceipt
{
    public uint Id { get; set; }

    public uint EnrollmentId { get; set; }

    public string Type { get; set; }

    public Enrollment Enrollment { get; set; }
}
