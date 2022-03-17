using System.Collections.Generic;
using EFHotel.Models.Owned;
using EFHotel.Tests.Base;

namespace EFHotel.Tests.Integration_Tests.Models;

public class HotelTests : BaseTest, IClassFixture<EFHotelFixture>
{
    public HotelTests(ITestOutputHelper outputHelper) : base(outputHelper)
    {
    }

    [Fact]
    public void CanAddANewHotel()
    { 
        ExecuteQueryInATransaction(AddNewHotel);

        void AddNewHotel()
        {
            var hotel = new Hotel()
            {
                Name = "LTT Hotel",
                Address = new Address()
                {
                    City = "Nakuru",
                    CountyCode = "021",
                    Street = "Shemeji, Lanet"
                },
            };
            var initialCount = Context.Hotels.Count();
            Context.Hotels.Add(hotel);
            Context.SaveChanges();
            Context.ChangeTracker.Clear();

            var newCount = Context.Hotels.Count();
            
            Assert.Equal(initialCount+1, newCount);

        }
    }
    
    [Fact]
    public void CanAddANewHotelWithRelations()
    { 
        ExecuteQueryInATransaction(AddNewHotel);

        void AddNewHotel()
        {
            var hotel = new Hotel()
            {
                Name = "LTT Hotel",
                Address = new Address()
                {
                    City = "Nakuru",
                    CountyCode = "021",
                    Street = "Shemeji, Lanet"
                },
                Specials = new List<Special>()
                {
                    new Special() {Name = "LTTSTore"}
                },
                RoomTypes = new List<RoomType>()
                {
                    new RoomType()
                    {
                        Title = "LMG",
                        Description = "Some description yeah",
                        Rooms = 10,
                        IsAccessibleToDisabled = true,
                        Size = "12*14 sq.m",
                        Price = new RoomPrice()
                        {
                            Price = "Ksh 1459.50",
                            ValidFrom = DateTime.Now.AddDays(-10),
                            ValidUntil = DateTime.Now.AddDays(15)
                        }
                    }
                }
            };
            var initialCount = Context.Hotels.Count();
            Context.Hotels.Add(hotel);
            Context.SaveChanges();
            Context.ChangeTracker.Clear();

            var newCount = Context.Hotels.Count();
            

            Assert.Equal(initialCount+1, newCount);

        }
    }

    [Fact]
    public void CanFetchHoteslWithRelations()
    {
        var q = Context.Hotels
            .Include(h => h.Specials)
            .Include(h => h.RoomTypes)
            .AsQueryable();
        OutputHelper.WriteLine(q.ToQueryString());
        
        var hotelsWithRelations = q.ToList();
        
        hotelsWithRelations.ForEach(h =>
        {
            Assert.NotNull(h.Specials);
            Assert.NotNull(h.RoomTypes);
            
            Assert.NotEmpty(h.Specials);
            Assert.NotEmpty(h.RoomTypes);
        });
    }

    [Fact]
    public void CanOnlyAddAHotelWithANameThatHasMaxiumumOf100Characters()
    {
        ExecuteQueryInATransaction(AddNewHotel);

        void AddNewHotel()
        {
            var hotel = new Hotel()
            {
                Address = new Address()
                {
                    City = "Nakuru",
                    CountyCode = "021",
                    Street = "Shemeji, Lanet"
                },
            };

            for (int i = 0; i < 101; i++)
            {
                hotel.Name += "a";
            }
             
            Context.Hotels.Add(hotel);

            Assert.Throws<DbUpdateException>(() => Context.SaveChanges());

        }
    }
}