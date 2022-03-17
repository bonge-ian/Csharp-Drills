using EFHotel.Models.Configuration;

namespace EFHotel.Models;

[EntityTypeConfiguration(typeof(HotelSpecialConfiguration))]
public class HotelSpecial : BaseModel
{
   
    public int HotelId { get; set; }
    
    [ForeignKey(nameof(HotelId))]
    [InverseProperty(nameof(Models.Hotel.HotelSpecials))]
    public Hotel Hotel { get; set; } = null!;
    
  
    public int SpecialId { get; set; }
    
    
    [ForeignKey(nameof(SpecialId))]
    [InverseProperty(nameof(Models.Special.HotelSpecials))]
    public Special Special { get; set; } = null!;
}