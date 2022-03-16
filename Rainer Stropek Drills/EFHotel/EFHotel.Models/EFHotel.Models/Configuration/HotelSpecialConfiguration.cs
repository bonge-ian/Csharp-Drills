using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFHotel.Models.Configuration;

public class HotelSpecialConfiguration : IEntityTypeConfiguration<HotelSpecial>
{
    public void Configure(EntityTypeBuilder<HotelSpecial> builder)
    {
        builder.Ignore(hs => hs.Id);
        builder.Ignore(hs => hs.CreatedAt);
        builder.Ignore(hs => hs.UpdatedAt);
    }
}