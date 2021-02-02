using Asyn_Inn.Models;
using Asyn_Inn.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Interfaces
{
  public interface IAmenities
  {
    Task<Amenities> Create(AmenitiesDTO amenity);
    Task<AmenitiesDTO> GetAmenity(int id);
    Task<List<AmenitiesDTO>> GetAmenities();
    Task<Amenities> updateAmenity(int id, Amenities amenity);
    Task DeleteAmenity(int id);
  }
}
