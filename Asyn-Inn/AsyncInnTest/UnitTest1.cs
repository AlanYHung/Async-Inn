using System;
using Xunit;
using System.Threading.Tasks;
using Asyn_Inn.Interfaces.Services;
using Asyn_Inn.Models.API;
using Asyn_Inn.Models;
using Asyn_Inn.Interfaces;

namespace AsyncInnTest
{
  public class TestAsyncInn : Mock
  {
    [Fact]
    public async Task CreateAndRemoveHotelTest()
    {
      // Arrange
      var newHotel = await CreateAndSaveTestHotel();
      var repository = new HotelRepository(_db);

      HotelDTO newHotelDTO = new HotelDTO
      {
        Name = "Test2",
        StreetAddress = "Test2",
        City = "Test2",
        State = "Test2",
        Phone = "Test2"
      };

      // Act
      Hotel testHotel = await repository.Create(newHotelDTO);

      //Assert
      var currentHotel = await repository.GetHotel(testHotel.Id);
      Assert.Equal("Test2", currentHotel.Name);

      // Act
      await repository.DeleteHotel(currentHotel.Id);

      // Assert
      Assert.NotEqual(currentHotel.Id, newHotel.Id);
    }

    [Fact]
    public async Task CreateAndRemoveRoomTest()
    {
      // Arrange
      var newRoom = await CreateAndSaveTestRoom();
      var repository = new RoomRepository(_db);

      RoomDTO newRoomDTO = new RoomDTO
      {
        Name = "Test2",
        RoomLayout = (Layout)0
      };

      // Act
      Room testRoom = await repository.Create(newRoomDTO);

      //Assert
      var currentRoom = await repository.GetRoom(testRoom.Id);
      Assert.Equal("Test2", currentRoom.Name);

      // Act
      await repository.DeleteRoom(currentRoom.Id);

      // Assert
      Assert.NotEqual(currentRoom.Id, newRoom.Id);
    }

    [Fact]
    public async Task CreateAndRemoveAmenityTest()
    {
      // Arrange
      var newAmenity = await CreateAndSaveTestAmenity();
      var repository = new AmenityRepository(_db);

      AmenitiesDTO newAmenityDTO = new AmenitiesDTO
      {
        Name = "Test2"
      };

      // Act
      Amenities testAmenity = await repository.Create(newAmenityDTO);

      //Assert
      var currentAmenity = await repository.GetAmenity(testAmenity.Id);
      Assert.Equal("Test2", currentAmenity.Name);

      // Act
      await repository.DeleteAmenity(currentAmenity.Id);

      // Assert
      Assert.NotEqual(currentAmenity.Id, newAmenity.Id);
    }

    //[Fact]
    //public async Task UpdateHotelTest()
    //{
    //  // Arrange
    //  var newHotel = await CreateAndSaveTestHotel();
    //  var repository = new HotelRepository(_db);

    //  HotelDTO newHotelDTO = new HotelDTO
    //  {
    //    Id = newHotel.Id,
    //    Name = "Test2",
    //    StreetAddress = "Test2",
    //    City = "Test2",
    //    State = "Test2",
    //    Phone = "Test2"
    //  };

    //  // Act
    //  Hotel testHotel = await repository.UpdateHotel(newHotel.Id, newHotelDTO);

    //  //Assert
    //  var currentHotel = await repository.GetHotel(testHotel.Id);
    //  Assert.Equal("Test2", currentHotel.Name);
    //}

    //[Fact]
    //public async Task DeleteHotelTest()
    //{
    //  // Arrange
    //  var newHotel = await CreateAndSaveTestHotel();
    //  var repository = new HotelRepository(_db);

    //  // Act
    //  await repository.DeleteHotel(newHotel.Id);

    //  //Assert
    //  var currentHotel = await repository.GetHotel(newHotel.Id);
    //  Assert.DoesNotContain(newHotel, h => )
    //}
  }
}
