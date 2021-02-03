using Asyn_Inn.Models;
using Asyn_Inn.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Interfaces
{
  public interface IHotelRoom
  {
    Task<HotelRoom> Create(HotelRoomDTO HotelRoom);
    Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber);
    Task<List<HotelRoomDTO>> GetHotelRooms();
    Task<HotelRoom> UpdateHotelRoom(int hotelId, int roomNumber, HotelRoomDTO HotelRoom);
    Task DeleteHotelRoom(int hotelId, int roomNumber);
  }
}
