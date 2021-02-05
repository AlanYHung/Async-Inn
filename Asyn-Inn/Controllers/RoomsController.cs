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
using Microsoft.AspNetCore.Authorization;

namespace Asyn_Inn.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class RoomsController : ControllerBase
  {
    private readonly IRoom _room;

    public RoomsController(IRoom room)
    {
      _room = room;
    }

    // GET: api/Rooms
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
    {
      return Ok(await _room.GetRooms());
    }

    // GET: api/Rooms/5
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<RoomDTO>> GetRoom(int id)
    {
      var room = await _room.GetRoom(id);

      if (room == null)
      {
        return NotFound();
      }

      return room;
    }

    // PUT: api/Rooms/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [Authorize(Roles = "Editor")]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRoom(int id, RoomDTO room)
    {
      if (id != room.Id)
      {
        return BadRequest();
      }

      var updatedRoom = await _room.UpdateRoom(id, room);
      return Ok(updatedRoom);
    }

    // POST: api/Rooms
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [Authorize(Roles = "Writer")]
    [HttpPost]
    public async Task<ActionResult<Room>> PostRoom(RoomDTO room)
    {
      await _room.Create(room);
      return CreatedAtAction("GetRoom", new { id = room.Id }, room);
    }

    // DELETE: api/Rooms/5
    [Authorize(Roles = "Administrator")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Room>> DeleteRoom(int id)
    {
      await _room.DeleteRoom(id);
      return NoContent();
    }

    // Add an amenity to a room
    // Post: api/4/6
    [Authorize(Roles = "Writer")]
    [HttpPost]
    [Route("{amenityId}/{roomId}")]
    public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
    {
      await _room.AddAmenity(roomId, amenityId);
      return NoContent();
    }

    [Authorize(Roles = "Administrator")]
    [HttpDelete]
    [Route("{amenityId}/{roomId}")]
    public async Task<IActionResult> RemoveAmenity(int roomId, int amenityId)
    {
      await _room.RemoveAmenity(roomId, amenityId);
      return NoContent();
    }
  }
}
