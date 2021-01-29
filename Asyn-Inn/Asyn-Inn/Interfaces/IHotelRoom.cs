using Asyn_Inn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Interfaces
{
  public interface IHotelRoom
  {
    Task<HotelRoom> Create(HotelRoom HotelRoom);
    Task<HotelRoom> GetHotelRoom(int id);
    Task<List<HotelRoom>> GetHotelRooms();
    Task<HotelRoom> UpdateHotelRoom(int id, HotelRoom HotelRoom);
    Task DeleteHotelRoom(int id);
  }
}
