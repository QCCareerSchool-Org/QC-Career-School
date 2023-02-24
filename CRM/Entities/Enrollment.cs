// <copyright file="Enrollment.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace CRM.Entities;

public class Enrollment
{
    public uint Id { get; set; }

    public uint StudentId { get; set; }

    public uint CourseId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public uint CurrencyId { get; set; }

    public decimal Cost { get; set; }

    public decimal Discount { get; set; }

    public Student Student { get; set; }

    public Course Course { get; set; }

    public Currency Currency { get; set; }

    public ICollection<Transaction> Transactions { get; set; }

    public ICollection<TaxReceipt> TaxReceipts { get; set; }
}
