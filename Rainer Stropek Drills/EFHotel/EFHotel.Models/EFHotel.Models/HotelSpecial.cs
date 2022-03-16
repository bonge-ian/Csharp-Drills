using EFHotel.Models.Configuration;

namespace EFHotel.Models;

[Keyless]
[Index(nameof(HotelId), nameof(SpecialId))]
[EntityTypeConfiguration(typeof(HotelSpecialConfiguration))]
public class HotelSpecial : BaseModel
{
    [ForeignKey(nameof(Hotel))]
    public int HotelId { get; set; }

    public Hotel Hotel { get; set; } = null!;
    
    
    [ForeignKey(nameof(Special))]
    public int SpecialId { get; set; }

    public Special Special { get; set; } = null!;
}