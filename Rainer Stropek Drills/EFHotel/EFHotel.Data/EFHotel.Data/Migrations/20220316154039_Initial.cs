using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFHotel.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address_City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address_CountyCode = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address_Street = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address_PostalCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Specials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specials", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "MEDIUMTEXT", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rooms = table.Column<uint>(type: "INT UNSIGNED", nullable: false),
                    Size = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAccessibleToDisabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomTypes_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HotelSpecial",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    SpecialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelSpecial", x => new { x.HotelId, x.SpecialId });
                    table.ForeignKey(
                        name: "FK_HotelSpecial_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelSpecial_Specials_SpecialId",
                        column: x => x.SpecialId,
                        principalTable: "Specials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoomPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "timestamp", nullable: true),
                    ValidUntil = table.Column<DateTime>(type: "timestamp", nullable: true),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomPrices_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Specials",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9918), "Spa", new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9928) },
                    { 2, new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9935), "Sauna", new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9936) },
                    { 3, new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9937), "Dog friendly", new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9938) },
                    { 4, new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9939), "Indoor pool", new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9940) },
                    { 5, new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9941), "Outdoor pool", new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9941) },
                    { 6, new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9945), "Bike rental", new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9945) },
                    { 7, new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9947), "eCar charging station", new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9947) },
                    { 8, new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9948), "Vegetarian cuisine", new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9949) },
                    { 9, new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9950), "Organic food", new DateTime(2022, 3, 16, 18, 40, 39, 67, DateTimeKind.Local).AddTicks(9951) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_Name",
                table: "Hotels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelSpecial_SpecialId",
                table: "HotelSpecial",
                column: "SpecialId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomPrices_RoomTypeId",
                table: "RoomPrices",
                column: "RoomTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_HotelId",
                table: "RoomTypes",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Specials_Name",
                table: "Specials",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelSpecial");

            migrationBuilder.DropTable(
                name: "RoomPrices");

            migrationBuilder.DropTable(
                name: "Specials");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
