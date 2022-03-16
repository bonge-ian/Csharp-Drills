﻿// <auto-generated />
using System;
using EFHotel.Data.EFStructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFHotel.Data.Migrations
{
    [DbContext(typeof(EFHotelContext))]
    [Migration("20220316123503_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EFHotel.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("EFHotel.Models.HotelSpecial", b =>
                {
                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialId")
                        .HasColumnType("int");

                    b.HasIndex("SpecialId");

                    b.HasIndex("HotelId", "SpecialId");

                    b.ToTable("HotelSpecial");
                });

            modelBuilder.Entity("EFHotel.Models.RoomPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("ValidFrom")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("ValidUntil")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId")
                        .IsUnique();

                    b.ToTable("RoomPrices");
                });

            modelBuilder.Entity("EFHotel.Models.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("MEDIUMTEXT");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAccessibleToDisabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<uint>("Rooms")
                        .HasColumnType("INT UNSIGNED");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("EFHotel.Models.Special", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Specials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(514),
                            Name = "Spa",
                            UpdatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(523)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(528),
                            Name = "Sauna",
                            UpdatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(529)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(530),
                            Name = "Dog friendly",
                            UpdatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(531)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(532),
                            Name = "Indoor pool",
                            UpdatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(532)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(533),
                            Name = "Outdoor pool",
                            UpdatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(534)
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(537),
                            Name = "Bike rental",
                            UpdatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(538)
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(539),
                            Name = "eCar charging station",
                            UpdatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(539)
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(540),
                            Name = "Vegetarian cuisine",
                            UpdatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(541)
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(542),
                            Name = "Organic food",
                            UpdatedAt = new DateTime(2022, 3, 16, 15, 35, 3, 618, DateTimeKind.Local).AddTicks(542)
                        });
                });

            modelBuilder.Entity("EFHotel.Models.Hotel", b =>
                {
                    b.OwnsOne("EFHotel.Models.Owned.Address", "Address", b1 =>
                        {
                            b1.Property<int>("HotelId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("CountyCode")
                                .IsRequired()
                                .HasMaxLength(3)
                                .HasColumnType("varchar(3)");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("longtext");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("HotelId");

                            b1.ToTable("Hotels");

                            b1.WithOwner()
                                .HasForeignKey("HotelId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("EFHotel.Models.HotelSpecial", b =>
                {
                    b.HasOne("EFHotel.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFHotel.Models.Special", "Special")
                        .WithMany()
                        .HasForeignKey("SpecialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Special");
                });

            modelBuilder.Entity("EFHotel.Models.RoomPrice", b =>
                {
                    b.HasOne("EFHotel.Models.RoomType", "RoomType")
                        .WithOne("Price")
                        .HasForeignKey("EFHotel.Models.RoomPrice", "RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("EFHotel.Models.RoomType", b =>
                {
                    b.HasOne("EFHotel.Models.Hotel", "Hotel")
                        .WithMany("RoomTypes")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("EFHotel.Models.Special", b =>
                {
                    b.HasOne("EFHotel.Models.Hotel", null)
                        .WithMany("Specials")
                        .HasForeignKey("HotelId");
                });

            modelBuilder.Entity("EFHotel.Models.Hotel", b =>
                {
                    b.Navigation("RoomTypes");

                    b.Navigation("Specials");
                });

            modelBuilder.Entity("EFHotel.Models.RoomType", b =>
                {
                    b.Navigation("Price")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
