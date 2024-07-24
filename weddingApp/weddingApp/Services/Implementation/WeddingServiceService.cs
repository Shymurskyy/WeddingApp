using Microsoft.EntityFrameworkCore;
using weddingApp.Data;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Services.Implementation
{
    public class WeddingServiceService : IWeddingServiceService
    {
        private readonly IConfiguration _configuration;
        private readonly WeddingAppContext _db;
        public WeddingServiceService(IConfiguration configuration, WeddingAppContext db)
        {
            _configuration = configuration;
            _db = db;
        }
        public async Task<IEnumerable<WeddingService>> GetAllWeddingServices()
        {
            Task<List<WeddingService>>? weddingServices = _db.WeddingServices.ToListAsync();
            return await weddingServices;
        }

        public async Task<WeddingService> GetWeddingServiceById(int id)
        {
            Task<WeddingService?>? weddingService = _db.WeddingServices.FirstOrDefaultAsync(x => x.Id == id);
            return await weddingService;
        }

        public async Task<WeddingService> CreateWeddingService(WeddingService weddingService)
        {
            _db.WeddingServices.Add(weddingService);
            await _db.SaveChangesAsync();
            return weddingService;
        }
        public async Task<WeddingService> UpdateWeddingService(WeddingService weddingService)
        {
            var exisitingWeddingService = await _db.WeddingServices.FindAsync(weddingService);
            if(exisitingWeddingService == null)
                throw new ArgumentException($"Wedding service with id {weddingService.Id} not found");

            exisitingWeddingService.Price = weddingService.Price;
            exisitingWeddingService.Number = weddingService.Number;
            exisitingWeddingService.Done = weddingService.Done;
            exisitingWeddingService.Service = weddingService.Service;
            _db.Update(exisitingWeddingService);
            await _db.SaveChangesAsync();
            return weddingService;

        }
        public async Task<WeddingService> DeleteWeddingService(WeddingService weddingService)
        {
            _db.Remove(weddingService);
            await _db.SaveChangesAsync();
            return weddingService;
        }
    }
}
