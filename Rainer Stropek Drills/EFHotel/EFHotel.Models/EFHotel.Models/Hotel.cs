using EFHotel.Models.Owned;

namespace EFHotel.Models;

[Index(nameof(Name), IsUnique = true)]
public class Hotel : BaseModel
{
    [StringLength(100)]
    public string Name { get; set; } = default!;
    
    public Address Address { get; set; } = default!;

    public ICollection<Special> Specials { get; set; } = null!;
    
    public ICollection<RoomType> RoomTypes { get; set; } = null!;
}