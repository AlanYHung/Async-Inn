using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using Asyn_Inn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Asyn_Inn.Models;
using System.Threading.Tasks;
using Xunit;
using Asyn_Inn.Models.API;

namespace AsyncInnTest
{
  public abstract class Mock : IDisposable
  {
    private readonly SqliteConnection _connection;
    protected readonly AsyncInnDbContext _db;

    public Mock()
    {
      _connection = new SqliteConnection("Filename=:memory:");
      _connection.Open();

      _db = new AsyncInnDbContext(
            new DbContextOptionsBuilder<AsyncInnDbContext>().UseSqlite(_connection)
                                                            .Options);

      _db.Database.EnsureCreated();
    }

    public void Dispose()
    {
      _db?.Dispose();
      _connection?.Dispose();
    }

    protected async Task<Hotel> CreateAndSaveTestHotel()
    {
      var newHotel = new Hotel
      {
        Name = "Async Inn",
        StreetAddress = "1111 Nowhere Lane",
        City = "Middle of Nowhere",
        State = "In Space",
        Country = "Does Not Exist",
        Phone = "999-999-9999"
      };

      _db.Hotels.Add(newHotel);
      await _db.SaveChangesAsync();
      _db.Entry(newHotel).State = EntityState.Detached;
      Assert.NotEqual(0, newHotel.Id);
      return newHotel;
    }

    protected async Task<Room> CreateAndSaveTestRoom()
    {
      var newRoom1 = new Room
      {
        Name = "Singularity X",
        RoomLayout = (Layout)0
      };

      var newRoom2 = new Room
      {
        Name = "Black Hole Y",
        RoomLayout = (Layout)1
      };

      _db.Rooms.Add(newRoom1);
      _db.Rooms.Add(newRoom2);
      await _db.SaveChangesAsync();
      _db.Entry(newRoom1).State = EntityState.Detached;
      _db.Entry(newRoom2).State = EntityState.Detached;
      Assert.NotEqual(0, newRoom1.Id);
      Assert.NotEqual(0, newRoom2.Id);
      return newRoom1;
    }

    protected async Task<Amenities> CreateAndSaveTestAmenity()
    {
      var newAmenity = new Amenities
      {
        Name = "Microwave"
      };

      _db.Amenity.Add(newAmenity);
      await _db.SaveChangesAsync();
      _db.Entry(newAmenity).State = EntityState.Detached;
      Assert.NotEqual(0, newAmenity.Id);
      return newAmenity;
    }

    protected async Task<RoomAmenities> CreateAndSaveTestRoomAmenity()
    {
      var newRoomAmenity = new RoomAmenities
      {
        RoomId = 1,
        AmenitiesId = 1
      };

      _db.RoomAmenity.Add(newRoomAmenity);
      await _db.SaveChangesAsync();
      _db.Entry(newRoomAmenity).State = EntityState.Detached;
      Assert.NotEqual(0, newRoomAmenity.RoomId);
      return newRoomAmenity;
    }

    protected async Task<HotelRoom> CreateAndSaveTestHotelRoom()
    {
      var newHotelRoom = new HotelRoom
      {
        HotelId = 1,
        RoomNumber = 555,
        RoomId = 1,
        Rate = 139.99M,
        PetFriendly = true
      };

      _db.HotelRooms.Add(newHotelRoom);
      await _db.SaveChangesAsync();
      _db.Entry(newHotelRoom).State = EntityState.Detached;
      Assert.NotEqual(0, newHotelRoom.HotelId);
      return newHotelRoom;
    }
  }
}
