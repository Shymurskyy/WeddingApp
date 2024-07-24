using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using weddingApp.Migrations;
using weddingApp.Model.DTO_s;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;
        public ServiceController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }
        [HttpGet("GetAllServices")]
        public async Task<ActionResult<IEnumerable<Service>>> GetAllService()
        {
            IEnumerable<Service>? services = await _serviceService.GetAllServices();
            if (services == null || services.Count() <= 0)
                return BadRequest("Empty table");

            IEnumerable<ServiceDto> serviceDto = _mapper.Map<IEnumerable<ServiceDto>>(services);
            return Ok(services);
        }
        [HttpGet("GetServiceById")]
        public async Task<ActionResult<Service>> GetServiceById(int id)
        {
            var service = _serviceService.GetServiceById(id);
            if (service == null)
                return BadRequest("This service dosen't exist.");

            var serviceDto = _mapper.Map<ServiceDto>(service);
            return Ok(serviceDto);
        }
        [HttpPost("CreateService")]
        public async Task<ActionResult> CreateService([FromBody] ServiceDto serviceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Service service = _mapper.Map<Service>(serviceDto);
            Service? createdService = await _serviceService.CreateService(service);

            ServiceDto? createdServiceDto = _mapper.Map<ServiceDto>(createdService);
            return CreatedAtAction("GetServiceById", new { id = createdServiceDto.Id }, createdServiceDto);
        }
        [HttpPut("UpdateService/{id}")]
        public async Task<ActionResult> UpdateThing(int id, [FromBody] ServiceDto serviceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Service? existingService = await _serviceService.GetServiceById(id);
            if (existingService == null)
                return NotFound();

            Service? serviceToUpdate = _mapper.Map<Service>(serviceDto);
            await _serviceService.UpdateService(serviceToUpdate);

            return Ok(_mapper.Map<ServiceDto>(serviceToUpdate));
        }
        [HttpDelete("DeleteService")]
        public async Task<ActionResult> DeleteService(int id)
        { 
            var service = await _serviceService.GetServiceById(id);
            if(service == null)
                return BadRequest("Incorrect id.");
            await _serviceService.DeleteService(service);
            return Ok();
        }
    }
}
