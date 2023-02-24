// <copyright file="Program.cs" company="QC Career School">
// All rights reserved.
// </copyright>

namespace TaxReceiptGenerator;

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using CRM;
using SC;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args);
        ConfigureServices(builder);

        using var host = builder.Build();

        using var scope = host.Services.CreateScope();

        var generator = scope.ServiceProvider.GetRequiredService<Generator>();
        await generator.RunAsync(2022);
    }

    private static void ConfigureServices(IHostBuilder builder)
    {
        builder.ConfigureServices((context, services) =>
        {
            services.AddDbContextFactory<CRMDbContext>(options =>
            {
                var connectionString = context.Configuration.GetConnectionString("CRM");
                var serverVersion = new MariaDbServerVersion(new Version(10, 5, 8));
                options.UseMySql(connectionString, serverVersion);
                if (context.HostingEnvironment.IsDevelopment())
                {
                    options
                        .LogTo(Console.WriteLine, LogLevel.Information)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors();
                }
            });
            services.AddDbContextFactory<StudentCenterDbContext>(options =>
            {
                var connectionString = context.Configuration.GetConnectionString("StudentCenter");
                var serverVersion = new MariaDbServerVersion(new Version(10, 5, 8));
                options.UseMySql(connectionString, serverVersion);
                if (context.HostingEnvironment.IsDevelopment())
                {
                    options
                        .LogTo(Console.WriteLine, LogLevel.Information)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors();
                }
            });
            services.AddScoped<Generator>();
        });
    }
}