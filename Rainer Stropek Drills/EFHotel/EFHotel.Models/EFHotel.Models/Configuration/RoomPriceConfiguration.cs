using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFHotel.Models.Configuration;

public class RoomPriceConfiguration : IEntityTypeConfiguration<RoomPrice>
{
    public void Configure(EntityTypeBuilder<RoomPrice> builder)
    {
        var culture = new CultureInfo("en-KE");
        var formatStyle = NumberStyles.AllowThousands | NumberStyles.AllowCurrencySymbol;

        builder.Property(rp => rp.Price)
            .HasConversion(
                toDb => decimal.Parse(toDb, formatStyle, culture),
                fromDb => $"{fromDb:C2}"
            );
    }
}