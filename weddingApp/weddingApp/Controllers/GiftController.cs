using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using weddingApp.Model.DTO_s;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _giftService;
        private readonly IMapper _mapper;
        public GiftController(IGiftService giftService, IMapper mapper)
        {
            _giftService = giftService;
            _mapper = mapper;
        }
        [HttpGet("GetAllGifts")]
        public async Task<ActionResult<IEnumerable<Gift>>> GetAllGifts()
        {
            IEnumerable<Gift>? gifts = await _giftService.GetAllGifts();
            if (gifts == null || gifts.Count() <= 0)
                return BadRequest("Empty table");
            else
                return Ok(gifts);
        }
        [HttpGet("GetGiftById")]
        public async Task<ActionResult<Gift>> GetGiftByID(int id)
        { 
            var gift = await _giftService.GetGiftById(id);
            if (gift == null)
                return NotFound();

            var giftDto = _mapper.Map<GiftDto>(gift);
            return Ok(giftDto);
        }
        [HttpPost("CreateGift")]
        public async Task<ActionResult> CreateGift([FromBody] GiftDto giftDto)
        { 
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            Gift? gift = _mapper.Map<Gift>(giftDto);
            Gift? createdGift = await _giftService.CreateGift(gift);
            GiftDto? createdGiftDto = _mapper.Map<GiftDto>(createdGift);

            return CreatedAtAction("GetGiftById", new { id = createdGiftDto.Id }, createdGiftDto);
        }
        [HttpPut("UpdateGift/{id}")]
        public async Task<ActionResult> UpdateGift(int id, [FromBody] GiftDto giftDto)
        { 
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingGift = await _giftService.GetGiftById(id);
            if(existingGift == null)
                return NotFound();

            Gift? giftToUpdate = _mapper.Map<Gift>(giftDto);
            await _giftService.UpdateGift(giftToUpdate);
            return Ok(_mapper.Map<GiftDto>(giftToUpdate));
        }
        [HttpDelete("DeleteGift")]
        public async Task<ActionResult> DeleteGift(int id)
        {
            var gift = await _giftService.GetGiftById(id);
            if (gift == null)
                return BadRequest("Incorrect id");
            await _giftService.DeleteGift(gift);
            return Ok(gift);
        }
    }
}
