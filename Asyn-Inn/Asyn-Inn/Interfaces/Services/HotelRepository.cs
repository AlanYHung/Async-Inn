using Asyn_Inn.Data;
using Asyn_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Interfaces.Services
{
  public class HotelRepository : IHotel
  {
    private AsyncInnDbContext _context;

    public HotelRepository(AsyncInnDbContext context)
    {
      _context = context;
    }

    public async Task<Hotel> Create(Hotel hotel)
    {
      _context.Entry(hotel).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return hotel;
    }

    public async Task DeleteHotel(int id)
    {
      Hotel hotel = await GetHotel(id);
      _context.Entry(hotel).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    public async Task<Hotel> GetHotel(int id)
    {
      Hotel hotel = await _context.Hotels.FindAsync(id);
      var hotelRoom = await _context.HotelRooms
                                    .Where(hr => hr.HotelId == id)
                                    .Include(hr => hr.Room)
                                    .ThenInclude(r => r.RoomAmenities)
                                    .ThenInclude(ra => ra.Amenity)
                                    .ToListAsync();
      return hotel;
    }

    public async Task<List<Hotel>> GetHotels()
    {
      var hotels = await _context.Hotels
                                 .Include(hr => hr.HotelRooms)
                                 .ThenInclude(hr => hr.Room)
                                 .ThenInclude(r => r.RoomAmenities)
                                 .ThenInclude(ra => ra.Amenity)
                                 .ToListAsync();
      return hotels;
    }

    public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
    {
      _context.Entry(hotel).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return hotel;
    }
  }
}
