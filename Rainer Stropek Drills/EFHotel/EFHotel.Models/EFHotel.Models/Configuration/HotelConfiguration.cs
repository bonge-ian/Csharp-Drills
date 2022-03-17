using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFHotel.Models.Configuration;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.HasMany(h => h.Specials)
            .WithMany(s => s.Hotels)
            .UsingEntity<HotelSpecial>(
                    jt => jt.HasOne(hs =>hs.Special)
                        .WithMany(s => s.HotelSpecials)
                        .HasForeignKey(hs => hs.SpecialId),
                    jt => jt.HasOne(hs => hs.Hotel)
                        .WithMany(h => h.HotelSpecials)
                        .HasForeignKey(hs => hs.HotelId)
            );
    }
}