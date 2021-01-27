using Asyn_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        //public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        //public DbSet<RoomAmenities> RoomAmenity { get; set; }
        public DbSet<Amenities> Amenity { get; set; }

        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, but does nothing
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>()
                .HasData(new Hotel
                {
                    Id = 1,
                    Name = "Async Inn",
                    StreetAddress = "1111 Nowhere Lane",
                    City = "Middle of Nowhere",
                    State = "In Space",
                    Country = "Does Not Exist",
                    Phone = "999-999-9999"
                });

            modelBuilder.Entity<Hotel>()
                .HasData(new Hotel
                {
                    Id = 2,
                    Name = "Async Shore",
                    StreetAddress = "2222 Nowhere Lane",
                    City = "Outside of Nowhere",
                    State = "In Galaxy",
                    Country = "Does Not Exist",
                    Phone = "777-777-7777"
                });

            modelBuilder.Entity<Hotel>()
                .HasData(new Hotel
                {
                    Id = 3,
                    Name = "Async Cliffs",
                    StreetAddress = "3333 Nowhere Lane",
                    City = "Out of Nowhere",
                    State = "In Universe",
                    Country = "Big Bang",
                    Phone = "111-111-1111"
                });

            modelBuilder.Entity<Room>()
                .HasData(new Room
                {
                    Id = 1,
                    Name = "Singularity X",
                    RoomLayout = (Layout)0
                });

            modelBuilder.Entity<Room>()
                .HasData(new Room
                {
                    Id = 2,
                    Name = "Black Hole Y",
                    RoomLayout = (Layout)1
                });

            modelBuilder.Entity<Room>()
                .HasData(new Room
                {
                    Id = 3,
                    Name = "Event Horizon Z",
                    RoomLayout = (Layout)2
                });

            modelBuilder.Entity<Amenities>()
                .HasData(new Amenities
                {
                    Id = 1,
                    Name = "Microwave"
                });

            modelBuilder.Entity<Amenities>()
                .HasData(new Amenities
                {
                    Id = 2,
                    Name = "50-inch 4K LED Television"
                });

            modelBuilder.Entity<Amenities>()
                .HasData(new Amenities
                {
                    Id = 3,
                    Name = "Swimming Pool"
                });

            //modelBuilder.Entity<HotelRoom>()
            //    .HasKey(HotelRoomNumber => new { HotelRoomNumber.HotelId, HotelRoomNumber.RoomNumber })
        }// end of OnModelCreating
    }
}
