using Asyn_Inn.Data;
using Asyn_Inn.Models;
using Asyn_Inn.Models.API;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Interfaces
{
  public class RoomRepository : IRoom
  {
    private AsyncInnDbContext _context;

    public RoomRepository(AsyncInnDbContext context)
    {
      _context = context;
    }

    public async Task<Room> Create(RoomDTO room)
    {
      Room newRoom = new Room()
      {
        Id = room.Id,
        Name = room.Name,
        RoomLayout = room.RoomLayout
      };

      _context.Entry(newRoom).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return newRoom;
    }

    public async Task DeleteRoom(int id)
    {
      RoomDTO room = await GetRoom(id);
      _context.Entry(room).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    public async Task<RoomDTO> GetRoom(int id)
    {
      RoomDTO newRoomDTO = await _context.Rooms
                                         .Where(r => r.Id == id)
                                         .Select(r => new RoomDTO
                                         {
                                           Id = r.Id,
                                           Name = r.Name,
                                           RoomLayout = r.RoomLayout,
                                           Amenities = r.RoomAmenities
                                                        .Select(ra => new AmenitiesDTO
                                                        {
                                                          Id = ra.Amenity.Id,
                                                          Name = ra.Amenity.Name
                                                        })
                                                        .ToList()
                                         })
                                         .FirstOrDefaultAsync();
      return newRoomDTO;
    }

    public async Task<List<RoomDTO>> GetRooms()
    {
      var rooms = await _context.Rooms
                                .Select(r => new RoomDTO
                                {
                                  Id = r.Id,
                                  Name = r.Name,
                                  RoomLayout = r.RoomLayout,
                                  Amenities = r.RoomAmenities
                                              .Select(ra => new AmenitiesDTO
                                              {
                                                Id = ra.Amenity.Id,
                                                Name = ra.Amenity.Name
                                              })
                                              .ToList()
                                })
                                .ToListAsync();
      return rooms;
    }

    public async Task<Room> UpdateRoom(int id, RoomDTO room)
    {
      Room newRoom = new Room()
      {
        Id = room.Id,
        Name = room.Name,
        RoomLayout = room.RoomLayout
      };

      _context.Entry(newRoom).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return newRoom;
    }

    public async Task AddAmenity(int roomId, int amenityId)
    {
      RoomAmenities roomAmenities = new RoomAmenities()
      {
        RoomId = roomId,
        AmenitiesId = amenityId
      };

      _context.Entry(roomAmenities).State = EntityState.Added;
      await _context.SaveChangesAsync();
    }

    public async Task RemoveAmenity(int roomId, int amenityId)
    {
      var result = await _context.RoomAmenity.FirstOrDefaultAsync(ra =>
                                                                  ra.AmenitiesId == amenityId && ra.RoomId == roomId);
      _context.Entry(result).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }
  }
}
