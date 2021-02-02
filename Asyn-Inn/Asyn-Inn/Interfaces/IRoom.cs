using Asyn_Inn.Models;
using Asyn_Inn.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Interfaces
{
  public interface IRoom
  {
    Task<Room> Create(RoomDTO room);
    Task<RoomDTO> GetRoom(int id);
    Task<List<RoomDTO>> GetRooms();
    Task<Room> UpdateRoom(int id, RoomDTO room);
    Task DeleteRoom(int id);
    Task AddAmenity(int roomId, int amenityId);
    Task RemoveAmenity(int roomId, int amenityId);
  }
}
