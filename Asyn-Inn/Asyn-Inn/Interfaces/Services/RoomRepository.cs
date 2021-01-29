using Asyn_Inn.Data;
using Asyn_Inn.Models;
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

    public async Task<Room> Create(Room room)
    {
      _context.Entry(room).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return room;
    }

    public async Task DeleteRoom(int id)
    {
      Room room = await GetRoom(id);
      _context.Entry(room).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    public async Task<Room> GetRoom(int id)
    {
      Room room = await _context.Rooms.FindAsync(id);
      var roomAmenities = await _context.RoomAmenity
                                        .Where(ra => ra.RoomId == id)
                                        .Include(ra => ra.Amenity)
                                        .ToListAsync();
      room.RoomAmenities = roomAmenities;
      var hotelRoom = await _context.HotelRooms
                                        .Where(hr => hr.RoomId == id)
                                        .Include(hr => hr.Hotel)
                                        .ToListAsync();
      room.HotelRooms = hotelRoom;
      return room;
    }

    public async Task<List<Room>> GetRooms()
    {
      var rooms = await _context.Rooms
                                .Include(ra => ra.RoomAmenities)
                                .ThenInclude(ra => ra.Amenity)
                                .ToListAsync();

      foreach (var room in rooms)
      {
        var hotelRoom = await _context.HotelRooms
                                      .Where(hr => hr.RoomId == room.Id)
                                      .Include(hr => hr.Hotel)
                                      .ToListAsync();
        room.HotelRooms = hotelRoom;
      }

      return rooms;
    }

    public async Task<Room> UpdateRoom(int id, Room room)
    {
      _context.Entry(room).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return room;
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
