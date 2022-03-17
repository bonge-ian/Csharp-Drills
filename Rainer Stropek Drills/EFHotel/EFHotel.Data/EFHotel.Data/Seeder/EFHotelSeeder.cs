using EFHotel.Data.EFStructures;
using EFHotel.Models.Base;
using MySqlConnector;

namespace EFHotel.Data.Seeder;

public static class EFHotelSeeder
{
    public static void ClearAndReseedDatabase(EFHotelContext context)
    {
        ClearDatabaseRecords(context);
        SeedData(context);
    }
    
    
    public static void InitializeDatabase(EFHotelContext context)
    {
        DropAndCreateDatabase(context);
        SeedData(context);
    }
    
    
    internal static void DropAndCreateDatabase(EFHotelContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.Migrate();
    }
    
    
    internal static void ClearDatabaseRecords(EFHotelContext context)
    {
        var entities = new[]
        {
            typeof(Hotel).FullName,
            typeof(Special).FullName,
            typeof(RoomType).FullName,
            typeof(RoomPrice).FullName,
            typeof(HotelSpecial).FullName,
        };

        foreach (var entity in entities)
        {
            var model = context.Model.FindEntityType(entity!);
            var tableName = model?.GetTableName();

            context.Database.ExecuteSqlRaw("SET FOREIGN_KEY_CHECKS = 0");
            context.Database.ExecuteSqlRaw($"DELETE FROM {tableName}");
            context.Database.ExecuteSqlRaw("SET FOREIGN_KEY_CHECKS = 1");
        }
    }
    
    internal static void SeedData(EFHotelContext context)
    {
        try
        {
            ProcessSeeder(context, context.Hotels!, DataGenerator.PopulateHotels());
            ProcessSeeder(context, context.HotelSpecial!, DataGenerator.PopulateHotelSpecials());
            ProcessSeeder(context, context.RoomTypes!, DataGenerator.PopulateRoomTypes());
            ProcessSeeder(context, context.RoomPrices!, DataGenerator.PopulatePrices());
        }
        catch (MySqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }

        static void ProcessSeeder<TModel>(
            EFHotelContext context,
            DbSet<TModel> table,
            List<TModel> records) where TModel : BaseModel
        {
            if (table.Any())
            {
                return;
            }

            var strategy = context.Database.CreateExecutionStrategy();

            strategy.Execute(
                () =>
                {
                    using var transaction = context.Database.BeginTransaction();
                    context.ChangeTracker.Clear();
                    try
                    {
                        table.AddRange(records); 
                        context.SaveChanges();
                        context.ChangeTracker.Clear();

                        transaction.Commit();
                        // context.ChangeTracker.Clear();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                });
        }
    }
}