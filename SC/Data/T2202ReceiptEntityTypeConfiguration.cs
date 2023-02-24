// <copyright file="T2202ReceiptEntityTypeConfiguration.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace SC.Data;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities;

/// <inheritdoc/>
public class T2202ReceiptEntityTypeConfiguration : IEntityTypeConfiguration<T2202Receipt>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<T2202Receipt> builder)
    {
        builder.ToTable("t2202a_receipts");

        builder
            .Property(t => t.Id)
            .HasColumnName("id");

        builder
            .Property(t => t.EnrollmentId)
            .HasColumnName("student_id");

        builder
            .Property(t => t.StartYear)
            .HasColumnName("start_year");

        builder
            .Property(t => t.StartMonth)
            .HasColumnName("start_month");

        builder
            .Property(t => t.EndYear)
            .HasColumnName("end_year");

        builder
            .Property(t => t.EndMonth)
            .HasColumnName("end_month");

        builder
            .Property(t => t.Tuition)
            .HasColumnName("tuition")
        .HasPrecision(8, 2);

        builder
            .Property(t => t.Address1)
            .HasColumnName("address1")
            .HasMaxLength(40);

        builder
            .Property(t => t.Address2)
            .HasColumnName("address2")
            .HasMaxLength(40);

        builder
            .Property(t => t.City)
            .HasColumnName("city")
            .HasMaxLength(31);

        builder
            .Property(t => t.PostalCode)
            .HasColumnName("postal_code")
            .HasMaxLength(10);

        builder
            .Property(t => t.ProvinceId)
            .HasColumnName("province_id");

        builder
            .Property(t => t.CountryId)
            .HasColumnName("country_id");

        builder
            .Property(t => t.Accessed)
            .HasColumnName("accesed");

        builder
            .Property(t => t.Version)
            .HasColumnName("version");
    }
}