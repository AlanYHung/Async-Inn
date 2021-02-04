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

    [Fact]
    public async Task CreateAndRemoveHotelRoomTest()
    {
      // Arrange
      var newHotelRoom = await CreateAndSaveTestHotelRoom();
      var repository = new HotelRoomRepository(_db);

      HotelRoomDTO newHotelRoomDTO = new HotelRoomDTO
      {
        HotelId = 1,
        RoomNumber = 7777,
        RoomId = 1,
        Rate = 139.99M,
        PetFriendly = true
      };

      // Act
      HotelRoom testHotelRoom = await repository.Create(newHotelRoomDTO);

      //Assert
      var currentHotelRoom = await repository.GetHotelRoom(testHotelRoom.HotelId, testHotelRoom.RoomNumber);
      Assert.Equal(7777, currentHotelRoom.RoomNumber);

      // Act
      await repository.DeleteHotelRoom(currentHotelRoom.HotelId, currentHotelRoom.RoomNumber);

      // Assert
      Assert.NotEqual(currentHotelRoom.RoomNumber, newHotelRoom.RoomNumber);
    }

    [Fact]
    public async Task UpdateHotelTest()
    {
      // Arrange
      var newHotel = await CreateAndSaveTestHotel();
      var repository = new HotelRepository(_db);

      HotelDTO newHotelDTO = new HotelDTO
      {
        Id = newHotel.Id,
        Name = "Test2",
        StreetAddress = "Test2",
        City = "Test2",
        State = "Test2",
        Phone = "Test2"
      };

      // Act
      var testHotel = await repository.UpdateHotel(newHotel.Id, newHotelDTO);

      //Assert
      var currentHotel = await repository.GetHotel(testHotel.Id);
      Assert.Equal("Test2", currentHotel.Name);
    }

    [Fact]
    public async Task UpdateRoomTest()
    {
      // Arrange
      var newRoom = await CreateAndSaveTestRoom();
      var repository = new RoomRepository(_db);

      RoomDTO newRoomDTO = new RoomDTO
      {
        Id = newRoom.Id,
        Name = "Test2",
        RoomLayout = (Layout)0
      };

      // Act
      var testRoom = await repository.UpdateRoom(newRoom.Id, newRoomDTO);

      //Assert
      var currentRoom = await repository.GetRoom(testRoom.Id);
      Assert.Equal("Test2", currentRoom.Name);
    }

    [Fact]
    public async Task UpdateAmenityTest()
    {
      // Arrange
      var newAmenity = await CreateAndSaveTestAmenity();
      var repository = new AmenityRepository(_db);

      Amenities newAmenityDTO = new Amenities
      {
        Id = newAmenity.Id,
        Name = "Test2"
      };

      // Act
      var testAmenity = await repository.updateAmenity(newAmenity.Id, newAmenityDTO);

      //Assert
      var currentAmenity = await repository.GetAmenity(testAmenity.Id);
      Assert.Equal("Test2", currentAmenity.Name);
    }

    [Fact]
    public async Task UpdateHotelRoomTest()
    {
      // Arrange
      var newHotelRoom = await CreateAndSaveTestHotelRoom();
      var repository = new HotelRoomRepository(_db);

      HotelRoomDTO newHotelRoomDTO = new HotelRoomDTO
      {
        HotelId = newHotelRoom.HotelId,
        RoomNumber = newHotelRoom.RoomNumber,
        RoomId = newHotelRoom.RoomId,
        Rate = 139.99M,
        PetFriendly = false
      };

      // Act
      var testHotelRoom = await repository.UpdateHotelRoom(newHotelRoomDTO.HotelId, newHotelRoomDTO.RoomNumber, newHotelRoomDTO);

      //Assert
      var currentHotelRoom = await repository.GetHotelRoom(newHotelRoomDTO.HotelId, newHotelRoomDTO.RoomNumber);
      Assert.False(currentHotelRoom.PetFriendly);
    }
  }
}
