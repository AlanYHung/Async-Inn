using Asyn_Inn.Data;
using Asyn_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Interfaces.Services
{
  public class AmenityRepository : IAmenities
  {
    private AsyncInnDbContext _context;

    public AmenityRepository(AsyncInnDbContext context)
    {
      _context = context;
    }

    public async Task<Amenities> Create(Amenities amenity)
    {
      _context.Entry(amenity).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return amenity;
    }

    public async Task DeleteAmenity(int id)
    {
      Amenities amenity = await GetAmenity(id);
      _context.Entry(amenity).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    public async Task<Amenities> GetAmenity(int id)
    {
      Amenities amenity = await _context.Amenity.FindAsync(id);
      return amenity;
    }

    public async Task<List<Amenities>> GetAmenities()
    {
      var amenities = await _context.Amenity.ToListAsync();
      return amenities;
    }

    public async Task<Amenities> updateAmenity(int id, Amenities amenity)
    {
      _context.Entry(amenity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return amenity;
    }
  }
}
