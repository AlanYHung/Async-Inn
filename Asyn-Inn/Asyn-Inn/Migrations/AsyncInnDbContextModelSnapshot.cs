﻿// <auto-generated />
using Asyn_Inn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Asyn_Inn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    partial class AsyncInnDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Asyn_Inn.Models.Amenities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Amenity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Microwave"
                        },
                        new
                        {
                            Id = 2,
                            Name = "50-inch 4K LED Television"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Swimming Pool"
                        });
                });

            modelBuilder.Entity("Asyn_Inn.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Middle of Nowhere",
                            Country = "Does Not Exist",
                            Name = "Async Inn",
                            Phone = "999-999-9999",
                            State = "In Space",
                            StreetAddress = "1111 Nowhere Lane"
                        },
                        new
                        {
                            Id = 2,
                            City = "Outside of Nowhere",
                            Country = "Does Not Exist",
                            Name = "Async Shore",
                            Phone = "777-777-7777",
                            State = "In Galaxy",
                            StreetAddress = "2222 Nowhere Lane"
                        },
                        new
                        {
                            Id = 3,
                            City = "Out of Nowhere",
                            Country = "Big Bang",
                            Name = "Async Cliffs",
                            Phone = "111-111-1111",
                            State = "In Universe",
                            StreetAddress = "3333 Nowhere Lane"
                        });
                });

            modelBuilder.Entity("Asyn_Inn.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<bool>("PetFriendly")
                        .HasColumnType("bit");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("HotelId", "RoomNumber");

                    b.HasIndex("RoomId");

                    b.ToTable("HotelRooms");

                    b.HasData(
                        new
                        {
                            HotelId = 1,
                            RoomNumber = 99,
                            PetFriendly = true,
                            Rate = 139.99m,
                            RoomId = 1
                        },
                        new
                        {
                            HotelId = 2,
                            RoomNumber = 777,
                            PetFriendly = false,
                            Rate = 1139.99m,
                            RoomId = 3
                        },
                        new
                        {
                            HotelId = 3,
                            RoomNumber = 1,
                            PetFriendly = true,
                            Rate = 1.99m,
                            RoomId = 2
                        });
                });

            modelBuilder.Entity("Asyn_Inn.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomLayout")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Singularity X",
                            RoomLayout = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Black Hole Y",
                            RoomLayout = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Event Horizon Z",
                            RoomLayout = 2
                        });
                });

            modelBuilder.Entity("Asyn_Inn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("AmenitiesId")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "AmenitiesId");

                    b.HasIndex("AmenitiesId");

                    b.ToTable("RoomAmenity");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            AmenitiesId = 3
                        },
                        new
                        {
                            RoomId = 2,
                            AmenitiesId = 1
                        },
                        new
                        {
                            RoomId = 3,
                            AmenitiesId = 2
                        });
                });

            modelBuilder.Entity("Asyn_Inn.Models.HotelRoom", b =>
                {
                    b.HasOne("Asyn_Inn.Models.Hotel", "Hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asyn_Inn.Models.Room", "Room")
                        .WithMany("HotelRooms")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Asyn_Inn.Models.RoomAmenities", b =>
                {
                    b.HasOne("Asyn_Inn.Models.Amenities", "Amenity")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asyn_Inn.Models.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
