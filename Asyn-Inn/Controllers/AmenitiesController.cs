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
  public class AmenitiesController : ControllerBase
  {
    private readonly IAmenities _amenity;

    public AmenitiesController(IAmenities amenity)
    {
      _amenity = amenity;
    }

    // GET: api/Amenities
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AmenitiesDTO>>> GetAmenity()
    {
      return await _amenity.GetAmenities();
    }

    // GET: api/Amenities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AmenitiesDTO>> GetAmenities(int id)
    {
      return await _amenity.GetAmenity(id);
    }

    // PUT: api/Amenities/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAmenities(int id, Amenities amenities)
    {
      if (id != amenities.Id)
      {
          return BadRequest();
      }

      var updatedAmenity = await _amenity.updateAmenity(id, amenities);
      return Ok(updatedAmenity);
    }

    // POST: api/Amenities
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<Amenities>> PostAmenities(AmenitiesDTO amenities)
    {
      await _amenity.Create(amenities);
      return CreatedAtAction("GetAmenities", new { id = amenities.Id }, amenities);
    }

    // DELETE: api/Amenities/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Amenities>> DeleteAmenities(int id)
    {
      await _amenity.DeleteAmenity(id);
      return NoContent();
    }
  }
}
