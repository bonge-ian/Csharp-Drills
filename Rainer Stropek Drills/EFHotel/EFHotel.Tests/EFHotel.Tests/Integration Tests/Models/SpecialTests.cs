using EFHotel.Models.Configuration;
using EFHotel.Tests.Base;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFHotel.Tests.Integration_Tests.Models;

[Collection("EFHotel Integration Tests")]
public class SpecialTests : BaseTest, IClassFixture<EFHotelFixture>
{
    public SpecialTests(ITestOutputHelper outputHelper) : base(outputHelper)
    {
        
    }

    [Fact]
    public void SpecialEntityHasInitialData()
    {
        var q = Context.Specials.AsQueryable();
        
        OutputHelper.WriteLine(q.ToQueryString());

        var specials = q.ToList();
        
        Assert.NotEmpty(specials);
        Assert.Equal(SpecialConfiguration.PopulateInitialSpecials().Count, specials.Count);
    }

    [Fact]
    public void CanAddANewSpecialEntity()
    {
        ExecuteQueryInATransaction(AddASpecialToDBOperation);
        
        void AddASpecialToDBOperation()
        {
            var special = new Special() {Name = "Omena"};
            var initialCount = Context.Specials.Count();

            Context.Specials.Add(special);
            Context.SaveChanges();
            Context.ChangeTracker.Clear();
            var newCount = Context.Specials.Count();
            
            Assert.True(special.Id > 0);
            Assert.Equal(initialCount+1, newCount);
        }
    }

    [Fact]
    public void CanFetchSpecialsWithItsRelations()
    {
        var q = Context.Specials.Include(s => s.Hotels).AsQueryable();
        
        OutputHelper.WriteLine(q.ToQueryString());

        var specialsWithHotels = q.ToList();
        
        specialsWithHotels.ForEach(sp =>
        {
            Assert.NotNull(sp.Hotels);
            Assert.NotEmpty(sp.Hotels);
        });
    }

    [Fact]
    public void CanOnlyAddUniqueSpecialToSpecialsTable()
    {
        ExecuteQueryInATransaction(AddNewSpecialOperation);

        void AddNewSpecialOperation()
        {
            var special = new Special() {Name = "Spa"};

            Context.Add(special);
            Action actionThatThrowsException = () => Context.SaveChanges();

            Assert.Throws<DbUpdateException>(actionThatThrowsException);
        }
    }

    [Fact]
    public void CanOnlyAddASpecialWithNameOfLessThan100Characters()
    {
        ExecuteQueryInATransaction(AddNewSpecialOperation);

        void AddNewSpecialOperation()
        {
            var special = new Special();

            for (int i = 0; i < 101; i++)
            {
                special.Name += "a";
            }

            Context.Add(special);
            Action actionThatThrowsException = () => Context.SaveChanges();

            Assert.Throws<DbUpdateException>(actionThatThrowsException);
        }
    }
}