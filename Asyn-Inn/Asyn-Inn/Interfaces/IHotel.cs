using Asyn_Inn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Interfaces
{
  public interface IHotel
  {
    Task<Hotel> Create(Hotel hotel);
    Task<Hotel> GetHotel(int id);
    Task<List<Hotel>> GetHotels();
    Task<Hotel> UpdateHotel(int id, Hotel hotel);
    Task DeleteHotel(int id);
  }
}
