using Asyn_Inn.Models;
using Asyn_Inn.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Interfaces
{
  public interface IHotel
  {
    Task<Hotel> Create(HotelDTO hotel);
    Task<HotelDTO> GetHotel(int id);
    Task<List<HotelDTO>> GetHotels();
    Task<Hotel> UpdateHotel(int id, HotelDTO hotel);
    Task DeleteHotel(int id);
  }
}
