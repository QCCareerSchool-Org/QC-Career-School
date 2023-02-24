// <copyright file="CurrencyEntityTypeConfiguration.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace CRM.Data;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities;

/// <inheritdoc/>
public class CurrencyEntityTypeConfiguration : IEntityTypeConfiguration<Currency>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.ToTable("currencies");

        builder
            .Property(c => c.Id)
            .HasColumnName("id");

        builder
            .Property(c => c.Code)
            .HasColumnName("code")
            .HasColumnType("CHAR")
            .HasMaxLength(3);

        builder
            .Property(c => c.Name)
            .HasColumnName("name")
            .HasMaxLength(255);

        builder
            .Property(c => c.Symbol)
            .HasColumnName("symbol")
            .HasMaxLength(5);
    }
}