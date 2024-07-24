using weddingApp.Model.Entities;

namespace weddingApp.Services.Interfaces
{
    public interface ICoupleService
    {
        Task<IEnumerable<Couple>> GetAllCouples();
        Task<Couple> GetCouplesById(int id);
        Task<Couple> CreateCouple(Couple couple);
        Task<Couple> UpdateCouple(Couple couple);
        Task<Couple> DeleteCouple(Couple couple);
    }
}
