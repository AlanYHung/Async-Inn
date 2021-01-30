using Asyn_Inn.Data;
using Asyn_Inn.Models;
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

    public async Task<HotelRoom> Create(HotelRoom HotelRoom)
    {
      _context.Entry(HotelRoom).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return HotelRoom;
    }

    public async Task DeleteHotelRoom(int hotelId, int roomNumber)
    {
      HotelRoom hotelRoom = await GetHotelRoom(hotelId, roomNumber);
      _context.Entry(hotelRoom).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    public async Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber)
    {
      HotelRoom hotelRoom = await _context.HotelRooms
                                          .Where(hr => (hr.HotelId == hotelId && hr.RoomNumber == roomNumber))
                                          .Include(hr => hr.Hotel)
                                          .Include(hr => hr.Room)
                                          .ThenInclude(r => r.RoomAmenities)
                                          .ThenInclude(ra => ra.Amenity)
                                          .FirstOrDefaultAsync();
      return hotelRoom;
    }

    public async Task<List<HotelRoom>> GetHotelRooms()
    {
      var hotelRoom = await _context.HotelRooms
                                    .Include(hr => hr.Hotel)
                                    .Include(hr => hr.Room)
                                    .ThenInclude(r => r.RoomAmenities)
                                    .ThenInclude(ra => ra.Amenity)
                                    .ToListAsync();
      return hotelRoom;
    }

    public async Task<HotelRoom> UpdateHotelRoom(int hotelId, int roomNumber, HotelRoom HotelRoom)
    {
      _context.Entry(HotelRoom).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return HotelRoom;
    }
  }
}
