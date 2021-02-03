using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Asyn_Inn.Data;
using Asyn_Inn.Models;
using Asyn_Inn.Interfaces;
using Asyn_Inn.Models.API;

namespace Asyn_Inn.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HotelRoomsController : ControllerBase
  {
    private readonly IHotelRoom _hotelRoom;

    public HotelRoomsController(IHotelRoom hotelRoom)
    {
      _hotelRoom = hotelRoom;
    }

    // GET: api/HotelRooms
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetHotelRooms()
    {
      return await _hotelRoom.GetHotelRooms();
    }

    // GET: api/HotelRooms/5
    [HttpGet("{hotelId}/{roomNumber}")]
    public async Task<ActionResult<HotelRoomDTO>> GetHotelRoom(int hotelId, int roomNumber)
    {
      return await _hotelRoom.GetHotelRoom(hotelId, roomNumber);
    }

    // PUT: api/HotelRooms/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{hotelId}/{roomNumber}")]
    public async Task<IActionResult> PutHotelRoom(int hotelId, int roomNumber, HotelRoomDTO hotelRoom)
    {
      if (hotelId != hotelRoom.HotelId && roomNumber != hotelRoom.RoomNumber)
      {
        return BadRequest();
      }

      var updatedHotelRoom = await _hotelRoom.UpdateHotelRoom(hotelId, roomNumber, hotelRoom);
      return Ok(updatedHotelRoom);
    }

    // POST: api/HotelRooms
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoomDTO hotelRoom)
    {
      await _hotelRoom.Create(hotelRoom);
      return CreatedAtAction("GetHotelRoom", new { HotelId = hotelRoom.HotelId, RoomNumber = hotelRoom.RoomNumber }, hotelRoom);
    }

    // DELETE: api/HotelRooms/5
    [HttpDelete("{hotelId}/{roomNumber}")]
    public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int hotelId, int roomNumber)
    {
      await _hotelRoom.DeleteHotelRoom(hotelId, roomNumber);
      return NoContent();
    }
  }
}
