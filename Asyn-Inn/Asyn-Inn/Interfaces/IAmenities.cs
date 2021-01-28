using Asyn_Inn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Interfaces
{
  public interface IAmenities
  {
    Task<Amenities> Create(Amenities amenity);
    Task<Amenities> GetAmenity(int id);
    Task<List<Amenities>> GetAmenities();
    Task<Amenities> updateAmenity(int id, Amenities amenity);
    Task DeleteAmenity(int id);
  }
}
