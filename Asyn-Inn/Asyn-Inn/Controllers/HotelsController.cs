﻿using System;
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
  public class HotelsController : ControllerBase
  {
    private readonly IHotel _hotel;

    public HotelsController(IHotel hotel)
    {
      _hotel = hotel;
    }

    // GET: api/Hotels
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
    {
      return Ok(await _hotel.GetHotels());
    }

    // GET: api/Hotels/5
    [HttpGet("{id}")]
    public async Task<ActionResult<HotelDTO>> GetHotel(int id)
    {
      var hotel = await _hotel.GetHotel(id);

      if (hotel == null)
      {
        return NotFound();
      }

      return hotel;
    }

    // PUT: api/Hotels/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHotel(int id, HotelDTO hotel)
    {
      if (id != hotel.Id)
      {
        return BadRequest();
      }

      var updatedHotel = await _hotel.UpdateHotel(id, hotel);
      return Ok(updatedHotel);
    }

    // POST: api/Hotels
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<Hotel>> PostHotel(HotelDTO hotel)
    {
      await _hotel.Create(hotel);
      return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
    }

    // DELETE: api/Hotels/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Hotel>> DeleteHotel(int id)
    {
      await _hotel.DeleteHotel(id);
      return NoContent();
    }
  }
}
