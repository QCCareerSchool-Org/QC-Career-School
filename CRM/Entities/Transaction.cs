// <copyright file="Transaction.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace CRM.Entities;

public class Transaction
{
    public uint Id { get; set; }

    public uint EnrollmentId { get; set; }

    public DateOnly TransactionDate { get; set; }

    public TimeOnly TransactionTime { get; set; }

    public decimal Amount { get; set; }

    public bool ExtraCharge { get; set; }

    public Enrollment Enrollment { get; set; }
}
