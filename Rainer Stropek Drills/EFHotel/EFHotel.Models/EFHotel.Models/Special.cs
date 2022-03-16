namespace EFHotel.Models;

[Index(nameof(Name), IsUnique = true)]
public class Special : BaseModel
{
    [StringLength(100)]
    public string Name { get; set; } = default!;
    
    
}