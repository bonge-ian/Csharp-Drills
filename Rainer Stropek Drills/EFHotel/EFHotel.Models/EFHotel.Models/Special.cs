using EFHotel.Models.Configuration;

namespace EFHotel.Models;

[Index(nameof(Name), IsUnique = true)]
[EntityTypeConfiguration(typeof(SpecialConfiguration))]
public class Special : BaseModel
{
    [StringLength(100)]
    public string Name { get; set; } = default!;
    

    public ICollection<Hotel> Hotels { get; set; } = null!;
    

    public ICollection<HotelSpecial> HotelSpecials { get; set; } = null!;
}