// <copyright file="StudentEntityTypeConfiguration.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace CRM.Data;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities;

/// <inheritdoc/>
public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("students");

        builder
            .Property(e => e.Id)
            .HasColumnName("id");

        builder
            .Property(e => e.FirstName)
            .HasColumnName("first_name");

        builder
            .Property(e => e.LastName)
            .HasColumnName("last_name");

        builder
            .Property(e => e.AddressLine1)
            .HasColumnName("address1");

        builder
            .Property(e => e.AddressLine2)
            .HasColumnName("address2");

        builder
            .Property(e => e.City)
            .HasColumnName("city");

        builder
            .Property(e => e.ProvinceId)
            .HasColumnName("province_id");

        builder
            .Property(e => e.PostalCode)
            .HasColumnName("postal_code");

        builder
            .Property(e => e.CountryId)
            .HasColumnName("country_id");

        builder
            .Property(e => e.TelephoneCountryCode)
            .HasColumnName("telephone_country_code");

        builder
            .Property(e => e.TelephoneNumber)
            .HasColumnName("telephone_number");

        builder
            .Property(e => e.EmailAddress)
            .HasColumnName("email_address");

        builder
            .HasOne(s => s.Country)
            .WithMany()
            .HasForeignKey(s => s.CountryId);

        builder
            .HasOne(s => s.Province)
            .WithMany()
            .HasForeignKey(s => s.ProvinceId);

        builder
            .HasMany(s => s.Enrollments)
            .WithOne(e => e.Student)
            .HasForeignKey(e => e.StudentId);
    }
}