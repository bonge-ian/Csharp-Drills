using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EFHotel.Data.EFStructures;

public class EFHotelContextFactory : IDesignTimeDbContextFactory<EFHotelContext>
{
    public EFHotelContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();

        var mysqlVersion = new MySqlServerVersion(new Version(8, 0, 28));

        DbContextOptionsBuilder<EFHotelContext> optionsBuilder = new();

        optionsBuilder.UseMySql(
            configuration.GetConnectionString("MySql"),
            mysqlVersion,
            options => options.EnableRetryOnFailure()

        ).LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors();
        
        return new EFHotelContext(optionsBuilder.Options);
    }
}