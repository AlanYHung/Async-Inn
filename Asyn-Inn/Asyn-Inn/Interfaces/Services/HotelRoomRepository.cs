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

    public async Task DeleteHotelRoom(int id)
    {
      HotelRoom hotelRoom = await GetHotelRoom(id);
      _context.Entry(hotelRoom).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    public async Task<HotelRoom> GetHotelRoom(int id)
    {
      //HotelRoom hotelRoom = await _context.HotelRooms
      //                                    .Where(hr => hr.HotelId == id)
      //                                    .Include(ra => ra.RoomAmenities)
      //                                    .FirstOrDefaultAsync();
      //return amenity;
      throw new NotImplementedException();
    }

    public async Task<List<HotelRoom>> GetHotelRooms()
    {
      throw new NotImplementedException();
    }

    public async Task<HotelRoom> UpdateHotelRoom(int id, HotelRoom HotelRoom)
    {
      throw new NotImplementedException();
    }
  }
}
