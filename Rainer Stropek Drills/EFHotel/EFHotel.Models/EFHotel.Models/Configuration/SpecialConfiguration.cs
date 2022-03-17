using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFHotel.Models.Configuration;

public class SpecialConfiguration : IEntityTypeConfiguration<Special>
{
    public void Configure(EntityTypeBuilder<Special> builder)
    {
        builder.HasData(PopulateInitialSpecials());
         
    }
    
    public static List<Special> PopulateInitialSpecials() => new List<Special>()
    {
        new Special() {Id = 1, Name = "Spa"},
        new Special() {Id = 2, Name = "Sauna"},
        new Special() {Id = 3, Name = "Dog friendly"},
        new Special() {Id = 4, Name = "Indoor pool"},
        new Special() {Id = 5, Name = "Outdoor pool"},
        new Special() {Id = 6, Name = "Bike rental"},
        new Special() {Id = 7, Name = "eCar charging station"},
        new Special() {Id = 8, Name = "Vegetarian cuisine"},
        new Special() {Id = 9, Name = "Organic food"},
    };
}