using System;
using EFHotel.Data.EFStructures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EFHotel.Tests.Helpers;

public static class DatabaseSetupHelper
{
    public static IConfiguration GetConfiguration(string path = "appsettings.json")
    {
        return new ConfigurationBuilder()
            .AddJsonFile(path, true, true)
            .Build();
    }

    public static EFHotelContext GetEFHotelContext(IConfiguration configuration)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EFHotelContext>();
        
        var (connStr, sqlVersion) = GetConnectionStringAndServerVersion(
            new Version(8,0,28),
            configuration.GetConnectionString("MySql")
        );

        optionsBuilder.UseMySql(connStr, sqlVersion, opt => opt.EnableRetryOnFailure())
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging();

        return new EFHotelContext(optionsBuilder.Options);
    }

    internal static (string connectionString, MySqlServerVersion mySqlServerVersion)
        GetConnectionStringAndServerVersion(
        Version? version,
        string? connectionString
        )
    {
        MySqlServerVersion serverVersion = new MySqlServerVersion( version ?? new Version(8, 0, 28 ) );

        var connString = connectionString ?? "server=localhost;user=root;password=password;database=efhotel_tests";
        
        
        return (connectionString: connString, mySqlServerVersion: serverVersion);
    }
}