using weddingApp.Model.Entities;

namespace weddingApp.Services.Interfaces
{
    public interface IGiftService
    {
        Task<IEnumerable<Gift>> GetAllGifts();
        Task<Gift> GetGiftById(int id);
        Task<Gift> CreateGift(Gift gift);
        Task<Gift> UpdateGift(Gift gift);
        Task<Gift> DeleteGift(Gift gift);
    }
}
