namespace EFHotel.Models;

public class RoomType : BaseModel
{
    [StringLength(100)]
    public string Title { get; set; } = default!;
    
    [StringLength(300)]
    [Column(TypeName = "MEDIUMTEXT")]
    public string Description { get; set; } = default!;
    
    [Column(TypeName = "INT UNSIGNED")]
    public int Rooms { get; set; }
    
    [StringLength(100)]
    public string Size { get; set; } = default!;

    public bool IsAccessibleToDisabled { get; set; } = false;
    
  
    public int HotelId { get; set; }
    
    [ForeignKey(nameof(HotelId))]
    [InverseProperty(nameof(Models.Hotel.RoomTypes))]
    public Hotel Hotel { get; set; } = default!;
    

    [InverseProperty(nameof(RoomPrice.RoomType))]
    public RoomPrice Price { get; set; } = default!;
}