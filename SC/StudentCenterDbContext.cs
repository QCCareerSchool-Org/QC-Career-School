// <copyright file="StudentCenterDbContext.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace SC;

using Microsoft.EntityFrameworkCore;
using Entities;
using SC.Data;

/// <inheritdoc/>
public class StudentCenterDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StudentCenterDbContext"/> class.
    /// </summary>
    /// <param name="options">The database options.</param>
    public StudentCenterDbContext(DbContextOptions<StudentCenterDbContext> options)
        : base(options)
    {
    }

    public DbSet<T2202Receipt> T2202Receipts { get; set; }

    public DbSet<Enrollment> Enrollments { get; set; }

    public DbSet<Province> Provinces { get; set; }

    public DbSet<Country> Countries { get; set; }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentCenterDbContext).Assembly);
        //modelBuilder.ApplyConfiguration(new EnrollmentEntityTypeConfiguration());
        //modelBuilder.ApplyConfiguration(new StudentEntityTypeConfiguration());
        //modelBuilder.ApplyConfiguration(new T2202ReceiptEntityTypeConfiguration());
    }
}
