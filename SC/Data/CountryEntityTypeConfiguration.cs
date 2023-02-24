// <copyright file="CountryEntityTypeConfiguration.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace SC.Data;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities;

/// <inheritdoc/>
internal class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("countries");

        builder
            .Property(c => c.Id)
            .HasColumnName("id");

        builder
            .Property(c => c.Code)
            .HasColumnName("code")
            .HasColumnType("CHAR")
            .HasMaxLength(2);

        builder
            .Property(c => c.Name)
            .HasColumnName("name")
            .HasMaxLength(255);

        builder
            .Property(c => c.ISOName)
            .HasColumnName("iso 3166-1")
            .HasMaxLength(3);

        builder
           .Property(c => c.PriceDisplayOrder)
           .HasColumnName("price_display_order")
           .HasMaxLength(6);

        builder
            .HasMany(c => c.Provinces)
            .WithOne(p => p.Country)
            .HasForeignKey(p => p.CountryId);
    }
}
