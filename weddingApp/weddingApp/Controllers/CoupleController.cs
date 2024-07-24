using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using weddingApp.Model;
using weddingApp.Model.DTO_s;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CoupleController : ControllerBase
    {
        private readonly ICoupleService _coupleService;
        private readonly IMapper _mapper;
        public CoupleController(ICoupleService coupleService, IMapper mapper)
        {
            _coupleService = coupleService;
            _mapper = mapper;
        }
        [HttpGet("GetAllCouples")]
        public async Task<ActionResult<IEnumerable<Couple>>> GetAllCouple()
        {
            IEnumerable<Couple>? couples = await _coupleService.GetAllCouples();
            if(couples == null || couples.Count() <= 0)
                return BadRequest("Empty table");
            var couplesDTO = _mapper.Map<IEnumerable<CoupleDto>>(couples);
            return Ok(couplesDTO);
        }
        [HttpGet("GetCoupleById")]
        public async Task<ActionResult<Couple>> GetCoupleById(int id)
        { 
            Couple? couple = await _coupleService.GetCouplesById(id);
            if (couple == null)
                return BadRequest("This couple dosn't exist.");

            CoupleDto? coupleDTO = _mapper.Map<CoupleDto>(couple);
            return Ok(coupleDTO);
        }
        [HttpPost("CreateCouple")]
        public async Task<ActionResult> CreateCouple([FromBody] CoupleDto coupleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Couple? couple = _mapper.Map<Couple>(coupleDto);
            await _coupleService.CreateCouple(couple);
            
            CoupleDto createdCoupleDto = _mapper.Map<CoupleDto>(couple);
            return CreatedAtAction("GetCoupleById", new { id = createdCoupleDto.Id }, createdCoupleDto);
        }
        [HttpPut("UpdateCouple/{id}")]
        public async Task<ActionResult> UpdateCouple([FromBody] CoupleDto coupleDto, int id)
        {
            if (ModelState.IsValid)
                return BadRequest(ModelState);

            Couple couple = await _coupleService.GetCouplesById(id);
            if(couple == null)
                return NotFound();

            Couple updatedCouple = _mapper.Map<Couple>(coupleDto);
            await _coupleService.UpdateCouple(updatedCouple);

            return Ok(_mapper.Map<CoupleDto>(updatedCouple));
        }
        [HttpDelete("DeleteCouple")]
        public async Task<ActionResult> DeleteCouple(int id)
        {
            Couple couple = await _coupleService.GetCouplesById(id);
            if(couple == null)
                return NotFound();
            await _coupleService.DeleteCouple(couple);
            return Ok();
        }

    }
}
