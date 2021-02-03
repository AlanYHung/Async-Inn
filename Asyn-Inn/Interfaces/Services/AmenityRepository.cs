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
  public class AmenityRepository : IAmenities
  {
    private AsyncInnDbContext _context;

    public AmenityRepository(AsyncInnDbContext context)
    {
      _context = context;
    }

    public async Task<Amenities> Create(AmenitiesDTO amenity)
    {
      Amenities amenities = new Amenities()
      {
        Id = amenity.Id,
        Name = amenity.Name
      };

      _context.Entry(amenities).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return amenities;
    }

    public async Task DeleteAmenity(int id)
    {
      Amenities amenity = await _context.Amenity.FindAsync(id);
      _context.Entry(amenity).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    public async Task<AmenitiesDTO> GetAmenity(int id)
    {
      AmenitiesDTO amenity = await _context.Amenity
                                           .Where(a => a.Id == id)
                                           .Select(amenity => new AmenitiesDTO
                                           {
                                             Id = amenity.Id,
                                             Name = amenity.Name
                                           })
                                           .FirstOrDefaultAsync();
      return amenity;
    }

    public async Task<List<AmenitiesDTO>> GetAmenities()
    {
      var amenities = await _context.Amenity
                                    .Select(amenity => new AmenitiesDTO
                                    {
                                      Id = amenity.Id,
                                      Name = amenity.Name,
                                    })
                                    .ToListAsync();
      return amenities;
    }

    public async Task<Amenities> updateAmenity(int id, Amenities amenity)
    {
      Amenities amenities = new Amenities()
      {
        Id = amenity.Id,
        Name = amenity.Name
      };

      _context.Entry(amenities).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return amenities;
    }
  }
}
