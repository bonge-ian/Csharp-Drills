using EFHotel.Models.Owned;

namespace EFHotel.Data.Seeder;

public static class DataGenerator
{
    public static List<Hotel> PopulateHotels() => new List<Hotel>()
    {
        new Hotel()
        {
            Id = 1,
            Name = "The Big Fish",
            Address = new Address()
            {
                City = "Nairobi",
                CountyCode = "047",
                Street = "Roasters, Garden Estate"
            }
        },
        new Hotel()
        {
            Id = 2,
            Name = "Kwa Maiko",
            Address = new Address()
            {
                City = "Kirinyaga",
                CountyCode = "024",
                Street = "Kutus"
            }
        },
        new Hotel()
        {
            Id = 3,
            Name = "Jasho Hotel",
            Address = new Address()
            {
                City = "Nairobi",
                CountyCode = "047",
                Street = "Duruma Road, River Road"
            }
        },
        new Hotel()
        {
            Id = 4,
            Name = "Sarova Hotel",
            Address = new Address()
            {
                City = "Naivasha",
                CountyCode = "010",
                Street = "Meneg, Naivaisha Inn",
                PostalCode = "P.O Box 1246-1100 Naivasha"
            }
        },
        new Hotel()
        {
            Id = 5,
            Name = "Diani Resort",
            Address = new Address()
            {
                City = "Nyali",
                CountyCode = "003",
                Street = "Manyatta, Diani",
                PostalCode = "P.O Box 6541-0310 Nyali"
            }
        },
    };

    public static List<RoomPrice> PopulatePrices() => new List<RoomPrice>()
    {
        new RoomPrice()
        {
            Id = 1,
            Price = "Ksh 900.00",
            ValidFrom = DateTime.Now.AddDays(-10),
            RoomTypeId = 1,
        },
        new RoomPrice()
        {
            Id = 2,
            Price = "Ksh 1000.00",
            ValidFrom = DateTime.Now.AddDays(-20),
            ValidUntil = DateTime.Now.AddDays(50),
            RoomTypeId =2,
        },
        new RoomPrice()
        {
            Id = 3,
            Price = "Ksh 1500.00",
            ValidFrom = DateTime.Now.AddDays(-40),
            ValidUntil = DateTime.Now.AddDays(60),
            RoomTypeId = 3,
        },
        new RoomPrice()
        {
            Id = 4,
            Price = "Ksh 2500.00",
            RoomTypeId = 4,
        },
        new RoomPrice()
        {
            Id = 5,
            Price = "Ksh 1400.00",
            ValidUntil = DateTime.Now.AddDays(40),
            RoomTypeId = 5,
        },
        new RoomPrice()
        {
            Id = 6,
            Price = "Ksh 500.00",
            ValidFrom = DateTime.Now,
            RoomTypeId = 7,
        },
        new RoomPrice()
        {
            Id = 7,
            Price = "Ksh 900.00",
            ValidFrom = DateTime.Now.AddDays(-21),
            ValidUntil = DateTime.Now.AddDays(6),
            RoomTypeId = 6,
        },
        new RoomPrice()
        {
            Id = 8,
            Price = "Ksh 1969.00",
            ValidFrom = DateTime.Now.AddDays(-20),
            ValidUntil = DateTime.Now.AddDays(31),
            RoomTypeId = 8,
        },
    };

    public static List<RoomType> PopulateRoomTypes() => new List<RoomType>()
    {
        new RoomType()
        {
            Id = 1,
            Title = "Deluxe 1",
            Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. ",
            Size = "10x11 sq.m.",
            Rooms = 50,
            IsAccessibleToDisabled = false,
            HotelId = 1,

        },
        new RoomType()
        {
            Id = 2,
            Title = "Deluxe 2",
            Description = "Voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. ",
            Size = "11x11 sq.m.",
            Rooms = 44,
            IsAccessibleToDisabled = true,
            HotelId = 1,
            
        },
        new RoomType()
        {
            Id = 1,
            Title = "Deluxe 1",
            Description = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born  ",
            Size = "11x11 sq.m.",
            Rooms = 20,
            IsAccessibleToDisabled = false,
            HotelId = 2,
        },
        new RoomType()
        {
            Id = 3,
            Title = "Deluxe 3",
            Description = "Inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. ",
            Size = "10x10 sq.m.",
            Rooms = 60,
            IsAccessibleToDisabled = true,
            HotelId = 3,
        },
        new RoomType()
        {
            Id = 4,
            Title = "Deluxe 4",
            Description = "On the other hand, we denounce with righteous indignation",
            Size = "12x12 sq.m.",
            Rooms = 40,
            IsAccessibleToDisabled = false,
            HotelId = 3,
        },
        new RoomType()
        {
            Id = 5,
            Title = "Deluxe 5",
            Description = "The wise man therefore always holds in these matters to this principle of selection",
            Size = "15x14 sq.m.",
            Rooms = 10,
            IsAccessibleToDisabled = true,
            HotelId = 4,

        },
        new RoomType()
        {
            Id = 6,
            Title = "Deluxe 6",
            Description = "Sed ut perspiciatis unde always holds in these matters cta sunt explicabo. ",
            Size = "11x11 sq.m.",
            Rooms = 22,
            IsAccessibleToDisabled = false,
            HotelId = 5,

        },
        new RoomType()
        {
            Id = 7,
            Title = "Deluxe 7",
            Description = "Section 1.10.33 of de Finibus Bonorum et Malorum, written by Cicero in 45 BC",
            Size = "13x12 sq.m.",
            Rooms = 60,
            IsAccessibleToDisabled = false,
            HotelId = 3,

        },
        new RoomType()
        {
            Id = 8,
            Title = "Deluxe 8",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore . ",
            Size = "14x10 sq.m.",
            Rooms = 45,
            IsAccessibleToDisabled = false,
            HotelId = 4,

        },
        new RoomType()
        {
            Id = 9,
            Title = "Deluxe 9",
            Description = "The sample application has been simplified and the static utility classes have been replaced by a LoremIpsumFactory ",
            Size = "14x17 sq.m.",
            Rooms = 32,
            IsAccessibleToDisabled = true,
            HotelId = 2,

        },
        
    };

    public static List<HotelSpecial> PopulateHotelSpecials() => new List<HotelSpecial>()
    {
        new HotelSpecial() {HotelId = 1, SpecialId = 1},
        new HotelSpecial() {HotelId = 2, SpecialId = 2},
        new HotelSpecial() {HotelId = 3, SpecialId = 3},
        new HotelSpecial() {HotelId = 4, SpecialId = 4},
        new HotelSpecial() {HotelId = 5, SpecialId = 5},
        new HotelSpecial() {HotelId = 1, SpecialId = 6},
        new HotelSpecial() {HotelId = 2, SpecialId = 7},
        new HotelSpecial() {HotelId = 4, SpecialId = 8},
        new HotelSpecial() {HotelId = 5, SpecialId = 9},
        new HotelSpecial() {HotelId = 3, SpecialId = 1},
        new HotelSpecial() {HotelId = 4, SpecialId = 2},
        new HotelSpecial() {HotelId = 2, SpecialId = 5},
        new HotelSpecial() {HotelId = 5, SpecialId = 6},
        new HotelSpecial() {HotelId = 1, SpecialId = 7},
        new HotelSpecial() {HotelId = 2, SpecialId = 3},
        new HotelSpecial() {HotelId = 4, SpecialId = 2},
        new HotelSpecial() {HotelId = 5, SpecialId = 1},
        new HotelSpecial() {HotelId = 1, SpecialId = 3},
    };
}