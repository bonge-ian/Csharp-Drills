using EFHotel.Models.Configuration;

namespace EFHotel.Models;

[EntityTypeConfiguration(typeof(RoomPriceConfiguration))]
public class RoomPrice : BaseModel
{
    public string Price { get; set; } = default!;

    public DateTime? ValidFrom { get; set; }

    public DateTime? ValidUntil { get; set; }

    public int RoomTypeId { get; set; }
    
    [ForeignKey(nameof(RoomTypeId))]
    [InverseProperty(nameof(Models.RoomType.Price))]
    public RoomType RoomType { get; set; } = default!;
}