// <copyright file="Generator.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace TaxReceiptGenerator;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using CRM.Entities;
using SC.Entities;
using SC;
using CRM;

public class Generator
{
    private readonly CRMDbContext crmContext;
    private readonly StudentCenterDbContext studentCenterContext;
    private readonly ILogger<Generator> logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="Generator"/> class.
    /// </summary>
    /// <param name="crmContext">A database context for the CRM.</param>
    /// <param name="studentCenterContext">A database context for the Student Center.</param>
    /// <param name="logger">A logger.</param>
    public Generator(CRMDbContext crmContext, StudentCenterDbContext studentCenterContext, ILogger<Generator> logger)
    {
        this.crmContext = crmContext;
        this.studentCenterContext = studentCenterContext;
        this.logger = logger;
    }

    /// <summary>
    /// Main entry point.
    /// </summary>
    /// <param name="year">The tax year.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public async Task RunAsync(int year)
    {
        var type = $"{year} T2202";

        var enrollments = await this.GetEnrollmentsAsync(2022, type);

        foreach (var enrollment in enrollments)
        {
            using var transaction = this.crmContext.Database.BeginTransaction();
            try
            {
                await this.crmContext.TaxReceipts.AddAsync(new TaxReceipt { EnrollmentId = enrollment.Id, Type = type });
                await this.crmContext.SaveChangesAsync();

                var studentCenterEnrollment = await this.GetEnrollment(enrollment.Course.Prefix, (int)enrollment.Id);

                SC.Entities.Province? studentCenterProvince = null;

                if (enrollment.Student.Province != null)
                {
                    studentCenterProvince = await this.GetProvince(enrollment.Student.Province.Code, enrollment.Student.Country.Code);
                }

                var studentCenterCountry = await this.GetCountry(enrollment.Student.Country.Code);

                await this.studentCenterContext.AddAsync(new T2202Receipt
                {
                    EnrollmentId = studentCenterEnrollment.Id,
                    StartYear = year,
                    StartMonth = default,
                    EndYear = year,
                    EndMonth = default,
                    Tuition = enrollment.AmountPaid,
                    Address1 = enrollment.Student.AddressLine1,
                    Address2 = enrollment.Student.AddressLine2,
                    City = enrollment.Student.City,
                    PostalCode = enrollment.Student.PostalCode,
                    ProvinceId = studentCenterProvince?.Id,
                    CountryId = studentCenterCountry.Id,
                    Accessed = 0,
                    Version = 1,
                });
                await this.studentCenterContext.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Could not save changes: {ex}", ex.Message);
            }
        }
    }

    private async Task<SC.Entities.Enrollment> GetEnrollment(string courseCode, int studentNumber)
    {
        return await this.studentCenterContext.Enrollments
            .Where(e => e.Course.Code == courseCode && e.StudentNumber == studentNumber)
            .FirstAsync();
    }

    private async Task<SC.Entities.Province> GetProvince(string code, string countryCode)
    {
        return await this.studentCenterContext.Provinces
            .Where(p => p.Code == code && p.Country.Code == countryCode)
            .FirstAsync();
    }

    private async Task<SC.Entities.Country> GetCountry(string code)
    {
        return await this.studentCenterContext.Countries
            .Where(c => c.Code == code)
            .FirstAsync();
    }

    /// <summary>
    /// Retrieves the enrollments that have paid $100 or more in tuition in the given year
    /// who do not already have a tax receipt record of the specified type.
    /// </summary>
    /// <param name="year">The year.</param>
    /// <param name="type">The tax receipt type.</param>
    /// <returns>A <see cref="Task"/> representing the enrollments.</returns>
    private async Task<ICollection<EnrollmentWithAmountPaid>> GetEnrollmentsAsync(int year, string type)
    {
        var transactionsGroupedByEnrollment = this.crmContext.Transactions
            .Where(t => t.TransactionDate.Year == year && t.ExtraCharge == false)
            .GroupBy(t => t.EnrollmentId)
            .Select(g => new { g.Key, AmountPaid = g.Sum(t => t.Amount) });

        return await this.crmContext.Enrollments
            .Include(e => e.Student.Country)
            .Include(e => e.Course)
            .Include(e => e.Currency)
            .Include(e => e.TaxReceipts)
            .Where(e => !e.TaxReceipts.Any(t => t.Type == type))
            .Where(e => e.Currency.Code == "CAD" && e.Student.Country.Code == "CA")
            .Join(
                transactionsGroupedByEnrollment,
                enrollment => enrollment.Id,
                transactionGroup => transactionGroup.Key,
                (enrollment, transactionGroup) => new { Enrollment = enrollment, TransactionGroup = transactionGroup })
            .Where(x => x.TransactionGroup.AmountPaid >= 100)
            .Select(anon2 => new EnrollmentWithAmountPaid
            {
                Id = anon2.Enrollment.Id,
                StudentId = anon2.Enrollment.StudentId,
                CourseId = anon2.Enrollment.CourseId,
                EnrollmentDate = anon2.Enrollment.EnrollmentDate,
                CurrencyId = anon2.Enrollment.CurrencyId,
                Cost = anon2.Enrollment.Cost,
                Discount = anon2.Enrollment.Discount,
                Student = anon2.Enrollment.Student,
                Course = anon2.Enrollment.Course,
                Currency = anon2.Enrollment.Currency,
                TaxReceipts = anon2.Enrollment.TaxReceipts,
                AmountPaid = anon2.TransactionGroup.AmountPaid,
            })
            .ToListAsync();
    }

    private class EnrollmentWithAmountPaid
    {
        public uint Id { get; set; }

        public uint StudentId { get; set; }

        public uint CourseId { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public uint CurrencyId { get; set; }

        public decimal Cost { get; set; }

        public decimal Discount { get; set; }

        public CRM.Entities.Student Student { get; set; }

        public CRM.Entities.Course Course { get; set; }

        public Currency Currency { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public ICollection<TaxReceipt> TaxReceipts { get; set; }

        public decimal AmountPaid { get; set; }
    }
}
