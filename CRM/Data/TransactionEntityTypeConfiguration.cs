// <copyright file="TransactionEntityTypeConfiguration.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace CRM.Data;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities;

/// <inheritdoc/>
internal class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<Transaction>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("transactions");

        builder
            .Property(c => c.Id)
            .HasColumnName("id");

        builder
            .Property(c => c.EnrollmentId)
            .HasColumnName("enrollment_id");

        builder
            .Property(c => c.TransactionDate)
            .HasColumnName("transaction_date");

        builder
            .Property(c => c.TransactionTime)
            .HasColumnName("transaction_time");

        builder
            .Property(c => c.Amount)
            .HasColumnName("amount")
            .HasPrecision(10, 2);

        builder
            .Property(c => c.ExtraCharge)
            .HasColumnName("extra_charge");
    }
}
