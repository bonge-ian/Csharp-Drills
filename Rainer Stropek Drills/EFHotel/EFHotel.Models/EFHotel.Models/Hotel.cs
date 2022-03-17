using EFHotel.Models.Configuration;
using EFHotel.Models.Owned;

namespace EFHotel.Models;

[Index(nameof(Name), IsUnique = true)]
[EntityTypeConfiguration(typeof(HotelConfiguration))]
public class Hotel : BaseModel
{
    [StringLength(100)]
    public string Name { get; set; } = default!;
    
    public Address Address { get; set; } = default!;
    
   
    public ICollection<Special> Specials { get; set; } = null!;
    
    public ICollection<RoomType> RoomTypes { get; set; } = null!;
    

    public ICollection<HotelSpecial> HotelSpecials { get; set; } = null!;
}