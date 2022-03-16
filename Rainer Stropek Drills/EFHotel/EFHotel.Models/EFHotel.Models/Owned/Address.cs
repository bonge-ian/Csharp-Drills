namespace EFHotel.Models.Owned;

[Owned]
public class Address
{
    public string City { get; set; } = default!;
    
    [MaxLength(3)]
    public string CountyCode { get; set; } = default!;

    public string Street { get; set; } = default!;

    public string? PostalCode { get; set; }
    
}