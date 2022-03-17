using EFHotel.Models.Base;
using Microsoft.Extensions.Logging;

namespace EFHotel.Data.EFStructures;

public class EFHotelContext : DbContext
{
    #region DBSets

    public DbSet<Hotel> Hotels => Set<Hotel>();
    
    public DbSet<HotelSpecial> HotelSpecial => Set<HotelSpecial>();
    
    public DbSet<RoomPrice> RoomPrices => Set<RoomPrice>();
    
    public DbSet<RoomType> RoomTypes => Set<RoomType>();
    
    public DbSet<Special> Specials => Set<Special>();

    #endregion

    #region Constructors
    
    public EFHotelContext(DbContextOptions options) : base(options){ }

    #endregion

    #region OnModelling, OnConfiguring,and ConfigureConventions Overrides

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var mysqlConnectionString = "server=localhost;user=root;password=password;database=efhotel";
            var mysqlVersion = new MySqlServerVersion(new Version(8, 0, 28));

            optionsBuilder.UseMySql(
                    mysqlConnectionString,
                    mysqlVersion,
                    options => options.EnableRetryOnFailure()
                ).LogTo(Console.WriteLine, LogLevel.Information)
                .EnableDetailedErrors();
        }
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTime>().HaveColumnType("timestamp");
    }

    #endregion

    #region Override SaveChanges

    public override int SaveChanges()
    {
        SetTimestamps();
        return base.SaveChanges();
    }
    
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        SetTimestamps();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        SetTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        SetTimestamps();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    #endregion

    #region Custom Actions

    private void SetTimestamps()
    {
        var entities = ChangeTracker.Entries().Where(
            e => e.Entity is BaseModel &&
                 (e.State == EntityState.Added || e.State == EntityState.Modified)
        );

        foreach (var entity in entities)
        {
            if (entity.State == EntityState.Added)
            {
                ((BaseModel)entity.Entity).CreatedAt = DateTime.UtcNow;
            }

            ((BaseModel)entity.Entity).UpdatedAt = DateTime.UtcNow;
        }
    }
    
    #endregion
}