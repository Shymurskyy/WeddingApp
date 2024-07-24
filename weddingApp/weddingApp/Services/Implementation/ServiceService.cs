using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;
using weddingApp.Data;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Services.Implementation
{
    public class ServiceService : IServiceService
    {
        private readonly IConfiguration _configuration;
        private readonly WeddingAppContext _db;
        public ServiceService(IConfiguration configuration, WeddingAppContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        public async Task<IEnumerable<Service>> GetAllServices()
        {
            var services = _db.Services.ToListAsync();
            return await services;
        }
        public async Task<Service> GetServiceById(int id)
        {
            var service = _db.Services.FirstOrDefaultAsync(x => x.Id == id);
            return await service;
        }

        public async Task<Service> CreateService(Service service)
        {
            _db.Services.Add(service);
            _db.SaveChanges();
            return service;
        }
        public async Task<Service> UpdateService(Service service)
        {
            Service? existingService = await _db.Services.FindAsync(service.Id);
            if (existingService == null)
                throw new ArgumentException($"Service wth id {service.Id} not found.");

            existingService.Name = service.Name;
            existingService.Description = service.Description;
            _db.Services.Update(existingService);
            _db.SaveChanges();

            return existingService;
        }

        public async Task<Service> DeleteService(Service service)
        {
            _db.Services.Remove(service);
            _db.SaveChanges();
            return service;
        }


    }
}
