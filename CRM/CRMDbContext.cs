// <copyright file="CRMDbContext.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace CRM;

using Microsoft.EntityFrameworkCore;
using Entities;
using CRM.Data;

/// <inheritdoc/>
public class CRMDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CRMDbContext"/> class.
    /// </summary>
    /// <param name="options">The database options.</param>
    public CRMDbContext(DbContextOptions<CRMDbContext> options)
        : base(options)
    {
    }

    public DbSet<Enrollment> Enrollments { get; set; }

    public DbSet<Transaction> Transactions { get; set; }

    public DbSet<TaxReceipt> TaxReceipts { get; set; }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CRMDbContext).Assembly);
        //modelBuilder.ApplyConfiguration(new CountryEntityTypeConfiguration());
        //modelBuilder.ApplyConfiguration(new CourseEntityTypeConfiguration());
        //modelBuilder.ApplyConfiguration(new CurrencyEntityTypeConfiguration());
        //modelBuilder.ApplyConfiguration(new EnrollmentEntityTypeConfiguration());
        //modelBuilder.ApplyConfiguration(new ProvinceEntityTypeConfiguration());
        //modelBuilder.ApplyConfiguration(new SchoolEntityTypeConfiguration());
        //modelBuilder.ApplyConfiguration(new StudentEntityTypeConfiguration());
        //modelBuilder.ApplyConfiguration(new TaxReceiptEntityTypeConfiguration());
        //modelBuilder.ApplyConfiguration(new TransactionEntityTypeConfiguration());
    }
}
