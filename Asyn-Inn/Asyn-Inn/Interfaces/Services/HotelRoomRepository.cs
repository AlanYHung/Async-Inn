using Asyn_Inn.Data;
using Asyn_Inn.Models;
using Asyn_Inn.Models.API;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Interfaces.Services
{
  public class HotelRoomRepository : IHotelRoom
  {
    private AsyncInnDbContext _context;

    public HotelRoomRepository(AsyncInnDbContext context)
    {
      _context = context;
    }

    public async Task<HotelRoom> Create(HotelRoomDTO HotelRoom)
    {
      HotelRoom hotelRoom = new HotelRoom()
      {
        HotelId = HotelRoom.HotelId,
        RoomNumber = HotelRoom.RoomNumber,
        Rate = HotelRoom.Rate,
        PetFriendly = HotelRoom.PetFriendly,
        RoomId = HotelRoom.RoomId,
      };

      _context.Entry(HotelRoom).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return hotelRoom;
    }

    public async Task DeleteHotelRoom(int hotelId, int roomNumber)
    {
      HotelRoomDTO hotelRoom = await GetHotelRoom(hotelId, roomNumber);
      _context.Entry(hotelRoom).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    public async Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber)
    {
      HotelRoom hotelRoom = await _context.HotelRooms
                                          .Where(hr => (hr.HotelId == hotelId && hr.RoomNumber == roomNumber))
                                          .Include(hr => hr.Hotel)
                                          .Include(hr => hr.Room)
                                          .ThenInclude(r => r.RoomAmenities)
                                          .ThenInclude(ra => ra.Amenity)
                                          .FirstOrDefaultAsync();

      HotelRoomDTO hotelRoomDTO = new HotelRoomDTO()
      {
        HotelId = hotelRoom.HotelId,
        RoomNumber = hotelRoom.RoomNumber,
        Rate = hotelRoom.Rate,
        PetFriendly = hotelRoom.PetFriendly,
        RoomId = hotelRoom.RoomId,
        Room = new RoomDTO()
        {
          Id = hotelRoom.Room.Id,
          Name = hotelRoom.Room.Name,
          RoomLayout = hotelRoom.Room.RoomLayout,
          Amenities = hotelRoom.Room.RoomAmenities
                                    .Select(ra => new AmenitiesDTO()
                                    {
                                      Id = ra.Amenity.Id,
                                      Name = ra.Amenity.Name
                                    })
                                    .ToList()
        }
      };

      return hotelRoomDTO;
    }

    public async Task<List<HotelRoomDTO>> GetHotelRooms()
    {
      var hotelRoom = await _context.HotelRooms
                                    .Select(hr => new HotelRoomDTO()
                                    {
                                      HotelId = hr.HotelId,
                                      RoomNumber = hr.RoomNumber,
                                      Rate = hr.Rate,
                                      PetFriendly = hr.PetFriendly,
                                      RoomId = hr.RoomId,
                                      Room = new RoomDTO()
                                      {
                                        Id = hr.Room.Id,
                                        Name = hr.Room.Name,
                                        RoomLayout = hr.Room.RoomLayout,
                                        Amenities = hr.Room.RoomAmenities
                                                           .Select(ra => new AmenitiesDTO()
                                                           {
                                                             Id = ra.Amenity.Id,
                                                             Name = ra.Amenity.Name
                                                           })
                                                           .ToList()
                                      }
                                    })
                                    .ToListAsync();
      return hotelRoom;
    }

    public async Task<HotelRoom> UpdateHotelRoom(int hotelId, int roomNumber, HotelRoomDTO HotelRoom)
    {
      HotelRoom hotelRoomDTO = new HotelRoom()
      {
        HotelId = HotelRoom.HotelId,
        RoomNumber = HotelRoom.RoomNumber,
        Rate = HotelRoom.Rate,
        PetFriendly = HotelRoom.PetFriendly,
        RoomId = HotelRoom.RoomId
      };

      _context.Entry(hotelRoomDTO).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return hotelRoomDTO;
    }
  }
}
