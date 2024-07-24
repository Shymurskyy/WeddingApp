using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using weddingApp.Model.DTO_s;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;
        private readonly IMapper _mapper;
        public GuestController(IGuestService guestService, IMapper mapper)
        {
            _guestService = guestService;
            _mapper = mapper;
        }
        [HttpGet("GetAllGuests")]
        public async Task<ActionResult<IEnumerable<Guest>>> GetAllGuests()
        {
            IEnumerable<Guest>? guests = await _guestService.GetAllGuests();
            if (guests == null || guests.Count() <= 0)
                return BadRequest("Empty table");
            else
                return Ok(guests);
        }
        [HttpGet("GetGuestById")]
        public async Task<ActionResult<Guest>> GetGuestById(int id)
        {
            Guest? guest = await _guestService.GetGuestById(id);
            if (guest == null)
                return NotFound();

            GuestDto? guestDto = _mapper.Map<GuestDto>(guest);
            return Ok(guestDto);
        }
        
        [HttpPost("CreateGuest")]
        public async Task<ActionResult> CreateGuest([FromBody]GuestDto guestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var guest = _mapper.Map<Guest>(guestDto);
            var createdGuest = await _guestService.CreateGuest(guest);
            var CreatedGuestDto = _mapper.Map<GuestDto>(createdGuest);

            return CreatedAtAction("GetGuestById", new { id = CreatedGuestDto.Id }, CreatedGuestDto);
        }

        [HttpPut("UpdateGuest")]
        public async Task<ActionResult> UpdateGuest([FromBody] GuestDto guestDto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var existingGuest = await _guestService.GetGuestById(guestDto.Id);
            if (existingGuest == null)
                return NotFound();

            var guestToUpdate = _mapper.Map<Guest>(existingGuest);
            await _guestService.UpdateGuest(guestToUpdate);
            return Ok( _mapper.Map<GuestDto>(guestToUpdate));
        }
        [HttpDelete("DeleteGuest")]
        public async Task<ActionResult> DeleteGuest(int id)
        {
            var guest = await _guestService.GetGuestById(id);
            if(guest == null)
                return BadRequest("Incorrect Id");
            await _guestService.DeleteGuest(guest);
            return Ok();
        }
    }
}
