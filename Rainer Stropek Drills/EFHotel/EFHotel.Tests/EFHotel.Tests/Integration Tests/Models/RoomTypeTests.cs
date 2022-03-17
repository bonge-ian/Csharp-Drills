using EFHotel.Data.Seeder;
using EFHotel.Tests.Base;

namespace EFHotel.Tests.Integration_Tests.Models;

public class RoomTypeTests : BaseTest, IClassFixture<EFHotelFixture>
{
    public RoomTypeTests(ITestOutputHelper outputHelper) : base(outputHelper)
    {
    }

    [Fact]
    public void ARoomTypeBelongsToAHotel()
    {
        ExecuteQueryInATransaction(AddARoomType);

        void AddARoomType()
        {
            var rt = new RoomType()
            {
                Title = "sdsfsdfs",
                Description = "SDfs sdf sdfsdfsdfsdf",
                Size = "12*15sq.m",
                IsAccessibleToDisabled = false,
                Rooms = 40,
                Hotel = new Hotel()
                {
                    Name = "LTTT",
                    Address = new()
                    {
                        City = "Ba",
                        CountyCode = "014",
                        Street = "dsfsdfsd"
                    }
                },
                Price = new RoomPrice()
                {
                    Price = "Ksh 1599",
                    ValidFrom = DateTime.Now
                }
            }; 
            
            Context.RoomTypes.Add(rt);
            Context.SaveChanges();
            Context.ChangeTracker.Clear();

            var rtt = Context.RoomTypes
                .Include(r => r.Hotel)
                .Where(r => r.Title == rt.Title)
                .First();
            
            Assert.IsType(typeof(Hotel), rtt.Hotel);
            
        }
    }

    [Fact]
    public void CanFetchRoomTypeWithRelations()
    {
        var q = Context.RoomTypes
            .Include(r => r.Hotel)
            .Include(r => r.Price)
            .AsQueryable();
        
        OutputHelper.WriteLine(q.ToQueryString());

        var rts = q.ToList();
        
        rts.ForEach(rt =>
        {
            Assert.IsType(typeof(Hotel), rt.Hotel);
            Assert.NotNull(rt.Hotel);
        });
        
    }
}