using Microsoft.EntityFrameworkCore;
using weddingApp.Data;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Services.Implementation
{
    public class GiftService : IGiftService
    {
        private readonly IConfiguration _configuration;
        private readonly WeddingAppContext _db;
        public GiftService(IConfiguration configuration, WeddingAppContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        public async Task<IEnumerable<Gift>> GetAllGifts()
        {
            Task<List<Gift>>? gifts = _db.Gifts.ToListAsync();
            return await gifts;
        }
        public async Task<Gift> GetGiftById(int id)
        {
            Task<Gift?>? gift = _db.Gifts.FirstOrDefaultAsync(x => x.Id == id);
            return await gift;
        }
        public async Task<Gift> CreateGift(Gift gift)
        {
            _db.Gifts.Add(gift);
            await _db.SaveChangesAsync();
            return gift;
        }

        public async Task<Gift> UpdateGift(Gift gift)
        {
            var existingGift = await _db.Gifts.FindAsync(gift.Id);
            if (existingGift == null)
                throw new ArgumentException($"Gift with id {gift.Id} not found");

            existingGift.Description = gift.Description;
            existingGift.Price = gift.Price;
            existingGift.IsPurchased = gift.IsPurchased;
            existingGift.Thing = gift.Thing;
            _db.Update(existingGift);
            await _db.SaveChangesAsync();
            return existingGift;
        }
        public async Task<Gift> DeleteGift(Gift gift)
        {
            _db.Gifts.Remove(gift);
            await _db.SaveChangesAsync();
            return gift;
        }
    }
}
