// <copyright file="CountryEntityTypeConfiguration.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace SC.Data;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities;

/// <inheritdoc/>
public class ProvinceEntityTypeConfiguration : IEntityTypeConfiguration<Province>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        builder.ToTable("provinces");

        builder
            .Property(c => c.Id)
            .HasColumnName("id");

        builder
          .Property(c => c.CountryId)
          .HasColumnName("country_id");

        builder
            .Property(c => c.Code)
            .HasColumnName("code")
            .HasColumnType("CHAR")
            .HasMaxLength(2);

        builder
            .Property(c => c.Name)
            .HasColumnName("name")
            .HasMaxLength(255);
    }
}