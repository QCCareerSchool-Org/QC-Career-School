// <copyright file="StudentEntityTypeConfiguration.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace SC.Data;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities;

/// <inheritdoc/>
internal class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("accounts");

        builder
            .Property(s => s.Id)
            .HasColumnName("id");

        builder
            .Property(s => s.CountryId)
            .HasColumnName("country_id");

        builder
            .Property(s => s.ProvinceId)
            .HasColumnName("province_id");

        builder
            .HasOne(s => s.Country)
            .WithMany()
            .HasForeignKey(s => s.CountryId);

        builder
            .HasOne(s => s.Province)
            .WithMany()
            .HasForeignKey(s => s.ProvinceId);
    }
}
