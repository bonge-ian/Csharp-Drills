using EFHotel.Data.EFStructures;
using EFHotel.Data.Seeder;
using EFHotel.Tests.Helpers;

namespace EFHotel.Tests;

public sealed class EFHotelFixture : IDisposable
{
    // private EFHotelContext _context;
    
    public EFHotelFixture()
    {
        var context = DatabaseSetupHelper.GetEFHotelContext(DatabaseSetupHelper.GetConfiguration());
        
        EFHotelSeeder.InitializeDatabase(context);
        
        context.Dispose();
    }
    
    public void Dispose() {}
}