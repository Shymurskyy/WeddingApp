using Microsoft.EntityFrameworkCore.Metadata.Internal;
using weddingApp.Model.Entities;

namespace weddingApp.Services.Interfaces
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> GetAllServices();
        Task<Service> GetServiceById(int id);
        Task<Service> CreateService(Service service);
        Task<Service> UpdateService(Service service);
        Task<Service> DeleteService(Service service);

    }
}
