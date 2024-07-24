using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using weddingApp.Model.DTO_s;
using weddingApp.Model.Entities;
using weddingApp.Services.Implementation;
using weddingApp.Services.Interfaces;

namespace weddingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeddingServiceController : ControllerBase
    {
        private readonly IWeddingServiceService _weddingServiceService;
        private readonly IMapper _mapper;
        public WeddingServiceController(IWeddingServiceService weddingServiceService, IMapper mapper)
        {
            _weddingServiceService = weddingServiceService;
            _mapper = mapper;
        }
        [HttpGet("GetAllWeddingServices")]
        public async Task<ActionResult<IEnumerable<WeddingService>>> GetAllWeddingService()
        { 
            IEnumerable<WeddingService>? weddingServices = await _weddingServiceService.GetAllWeddingServices();
            if (weddingServices == null && weddingServices.Count() <= 0)
                return BadRequest("Empty table");
            else
                return Ok(weddingServices);
        }
        [HttpGet("GetWeddingServiceById")]
        public async Task<ActionResult<WeddingService>> GetWeddingServiceById(int id)
        {
            Task<WeddingService>? weddingService = _weddingServiceService.GetWeddingServiceById(id);
            if (weddingService == null)
                return NotFound();
            WeddingServiceDto? weddingServiceDto = _mapper.Map<WeddingServiceDto>(weddingService);
            return Ok(weddingServiceDto);
        }
        [HttpPost("CreateWeddingService")]
        public async Task<ActionResult> CreateWeddingService([FromBody] WeddingService weddingServiceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            WeddingService? weddingService= _mapper.Map<WeddingService>(weddingServiceDto);
            WeddingService? createdWeddingService = await _weddingServiceService.CreateWeddingService(weddingService);
            WeddingServiceDto? createdWeddingServiceDto = _mapper.Map<WeddingServiceDto>(createdWeddingService);

            return CreatedAtAction("GetWeddingServiceById", new { id = createdWeddingServiceDto.Id }, createdWeddingServiceDto);
        }

        [HttpPut("UpdateWeddingService/{id}")]
        public async Task<ActionResult> UpdateWeddingService(int id, [FromBody] WeddingServiceDto weddingServiceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            WeddingService? existingWeddingService = await _weddingServiceService.GetWeddingServiceById(id);
            if (existingWeddingService == null)
                return NotFound();

            WeddingService? weddingServiceToUpdate = _mapper.Map<WeddingService>(weddingServiceDto);
            await _weddingServiceService.UpdateWeddingService(weddingServiceToUpdate);
            return Ok(_mapper.Map<WeddingServiceDto>(weddingServiceToUpdate));
        }

        [HttpDelete("DeleteWeddingService")]
        public async Task<ActionResult> DeleteWeddingService(int id)
        {
            var weddingService = await _weddingServiceService.GetWeddingServiceById(id);
            if (weddingService == null)
                return BadRequest("Incorrect Id");
            await _weddingServiceService.DeleteWeddingService(weddingService);
            return Ok(weddingService);
        }
    }
}
