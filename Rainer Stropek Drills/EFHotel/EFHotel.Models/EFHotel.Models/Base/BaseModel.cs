namespace EFHotel.Models.Base;

public abstract class BaseModel
{
    [Key, DatabaseGenerated((DatabaseGeneratedOption.Identity))]
    public int Id { get; set; }
    
    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}