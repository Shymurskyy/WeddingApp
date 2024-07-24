using weddingApp.Model.Entities;

namespace weddingApp.Services.Interfaces
{
    public interface IWeddingServiceService
    {
        Task<IEnumerable<WeddingService>> GetAllWeddingServices();
        Task<WeddingService> GetWeddingServiceById(int id);
        Task<WeddingService> CreateWeddingService(WeddingService weddingService);
        Task<WeddingService> UpdateWeddingService(WeddingService weddingService);
        Task<WeddingService> DeleteWeddingService(WeddingService weddingService);
    }
}
