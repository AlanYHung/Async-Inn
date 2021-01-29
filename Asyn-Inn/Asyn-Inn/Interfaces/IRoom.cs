using Asyn_Inn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Interfaces
{
  public interface IRoom
  {
    Task<Room> Create(Room room);
    Task<Room> GetRoom(int id);
    Task<List<Room>> GetRooms();
    Task<Room> UpdateRoom(int id, Room room);
    Task DeleteRoom(int id);
    Task AddAmenity(int roomId, int amenityId);
    Task RemoveAmenity(int roomId, int amenityId);
  }
}
