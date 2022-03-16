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
                name: "Specials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specials_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "HotelSpecial",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    SpecialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
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

            migrationBuilder.InsertData(
                table: "Specials",
                columns: new[] { "Id", "CreatedAt", "HotelId", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(514), null, "Spa", new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(523) },
                    { 2, new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(528), null, "Sauna", new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(529) },
                    { 3, new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(530), null, "Dog friendly", new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(531) },
                    { 4, new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(532), null, "Indoor pool", new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(532) },
                    { 5, new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(533), null, "Outdoor pool", new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(534) },
                    { 6, new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(537), null, "Bike rental", new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(538) },
                    { 7, new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(539), null, "eCar charging station", new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(539) },
                    { 8, new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(540), null, "Vegetarian cuisine", new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(541) },
                    { 9, new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(542), null, "Organic food", new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(542) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_Name",
                table: "Hotels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelSpecial_HotelId_SpecialId",
                table: "HotelSpecial",
                columns: new[] { "HotelId", "SpecialId" });

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
                name: "IX_Specials_HotelId",
                table: "Specials",
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
