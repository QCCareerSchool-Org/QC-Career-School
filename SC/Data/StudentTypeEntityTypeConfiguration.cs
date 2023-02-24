// <copyright file="StudentTypeEntityTypeConfiguration.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace SC.Data;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities;

/// <inheritdoc/>
internal class StudentTypeEntityTypeConfiguration : IEntityTypeConfiguration<StudentType>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<StudentType> builder)
    {
        builder
            .ToTable("countries")
            .HasKey(s => s.Type);

        builder
            .Property(s => s.Type)
            .HasColumnName("type");

        builder
            .Property(s => s.Profile)
            .HasColumnName("profile");
    }
}