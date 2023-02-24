// <copyright file="TaxReceiptEntityTypeConfiguration.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace CRM.Data;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities;

/// <inheritdoc/>
public class TaxReceiptEntityTypeConfiguration : IEntityTypeConfiguration<TaxReceipt>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<TaxReceipt> builder)
    {
        builder.ToTable("tax_receipts");

        builder
            .Property(c => c.Id)
            .HasColumnName("id");

        builder
            .Property(c => c.EnrollmentId)
            .HasColumnName("enrollment_id");

        builder
            .Property(c => c.Type)
            .HasColumnName("type")
            .HasMaxLength(25);
    }
}