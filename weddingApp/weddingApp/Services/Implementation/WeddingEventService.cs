using Microsoft.EntityFrameworkCore;
using weddingApp.Data;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Services.Implementation
{
    public class WeddingEventService : IWeddingEventService
    {
        private readonly IConfiguration _configuration;
        private readonly WeddingAppContext _db;
        public WeddingEventService(IConfiguration configuration, WeddingAppContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        public async Task<IEnumerable<WeddingEvent>> GetAllWeddingEvents()
        {
            var weddingEvents = _db.WeddingEvents.ToListAsync();
            return await weddingEvents;
        }
        public async Task<WeddingEvent> GetWeddingEventById(int id)
        {
            Task<WeddingEvent?>? weddingEvent = _db.WeddingEvents.FirstOrDefaultAsync(x=>x.Id == id);
            return await weddingEvent;
        }
        public async Task<WeddingEvent> CreateWeddingEvent(WeddingEvent weddingEvent)
        {
            _db.WeddingEvents.Add(weddingEvent);
            await _db.SaveChangesAsync();
            return weddingEvent;
        }

        public async Task<WeddingEvent> UpdateWeddingEvent(WeddingEvent weddingEvent)
        {
            WeddingEvent? existingWeddingEvent = await _db.WeddingEvents.FindAsync(weddingEvent.Id);
            if (existingWeddingEvent == null)
                throw new ArgumentException($"Wedding event with id {weddingEvent.Id} not found");
            
            existingWeddingEvent.Couple = weddingEvent.Couple;
            existingWeddingEvent.WeddingDate = weddingEvent.WeddingDate;
            existingWeddingEvent.Budget = weddingEvent.Budget;
            existingWeddingEvent.Name = weddingEvent.Name;
            existingWeddingEvent.WeddingDate = weddingEvent.WeddingDate;
            _db.Update(existingWeddingEvent);
            await _db.SaveChangesAsync();
            return weddingEvent;
        }
        public async Task<WeddingEvent> DeleteWeddingEvent(WeddingEvent weddingEvent)
        {
            _db.WeddingEvents.Remove(weddingEvent);
            await _db.SaveChangesAsync();
            return weddingEvent;
        }

        public async Task<WeddingEvent> AddGift(int idWeddingEvent, int idGift)
        {
            WeddingEvent? existingWeddingEvent = await _db.WeddingEvents.FindAsync(idWeddingEvent);
            if (existingWeddingEvent == null)
                throw new ArgumentException($"Wedding event with id {idWeddingEvent} not found");
            Gift? existingGift = await _db.Gifts.FindAsync(idGift);
            if (existingGift == null)
                throw new ArgumentException($"Gift with id {idGift} not found");
            existingWeddingEvent.Gifts.Add(existingGift);
            _db.Update(existingWeddingEvent);
            await _db.SaveChangesAsync();
            return existingWeddingEvent;
        }

        public async Task<WeddingEvent> RemoveGift(int idWeddingEvent, int idGift)
        {
            WeddingEvent? existingWeddingEvent = await _db.WeddingEvents.FindAsync(idWeddingEvent);
            if (existingWeddingEvent == null)
                throw new ArgumentException($"Wedding event with id {idWeddingEvent} not found");
            Gift? existingGift = await _db.Gifts.FindAsync(idGift);
            if (existingGift == null)
                throw new ArgumentException($"Gift with id {idGift} not found");
            existingWeddingEvent.Gifts.Remove(existingGift);
            _db.Update(existingWeddingEvent);
            await _db.SaveChangesAsync();
            return existingWeddingEvent;
        }

        public async Task<WeddingEvent> AddGuest(int idWeddingEvent, int idGuest)
        {
            WeddingEvent? existingWeddingEvent = await _db.WeddingEvents.FindAsync(idWeddingEvent);
            if (existingWeddingEvent == null)
                throw new ArgumentException($"Wedding event with id {idWeddingEvent} not found");
            Guest? existingGuest = await _db.Guests.FindAsync(idGuest);
            if (existingGuest == null)
                throw new ArgumentException($"Guest with id {idGuest} not found");
            existingWeddingEvent.Guests.Add(existingGuest);
            _db.Update(existingWeddingEvent);
            await _db.SaveChangesAsync();
            return existingWeddingEvent;
        }

        public async Task<WeddingEvent> RemoveGuest(int idWeddingEvent, int idGuest)
        {
            WeddingEvent? existingWeddingEvent = await _db.WeddingEvents.FindAsync(idWeddingEvent);
            if (existingWeddingEvent == null)
                throw new ArgumentException($"Wedding event with id {idWeddingEvent} not found");
            Guest? existingGuest = await _db.Guests.FindAsync(idGuest);
            if (existingGuest == null)
                throw new ArgumentException($"Guest with id {idGuest} not found");
            existingWeddingEvent.Guests.Remove(existingGuest);
            _db.Update(existingWeddingEvent);
            await _db.SaveChangesAsync();
            return existingWeddingEvent;
        }

        public async Task<WeddingEvent> AddWeddingService(int idWeddingEvent, int idWeddingService)
        {
            WeddingEvent? existingWeddingEvent = await _db.WeddingEvents.FindAsync(idWeddingEvent);
            if (existingWeddingEvent == null)
                throw new ArgumentException($"Wedding event with id {idWeddingEvent} not found");
            WeddingService? existingWeddingService = await _db.WeddingServices.FindAsync(idWeddingService);
            if (existingWeddingService == null)
                throw new ArgumentException($"Wedding Service with id {idWeddingService} not found");
            existingWeddingEvent.WeddingServices.Add(existingWeddingService);
            _db.Update(existingWeddingEvent);
            await _db.SaveChangesAsync();
            return existingWeddingEvent;
        }

        public async Task<WeddingEvent> RemoveWeddingService(int idWeddingEvent, int idWeddingService)
        {
            WeddingEvent? existingWeddingEvent = await _db.WeddingEvents.FindAsync(idWeddingEvent);
            if (existingWeddingEvent == null)
                throw new ArgumentException($"Wedding event with id {idWeddingEvent} not found");
            WeddingService? existingWeddingService = await _db.WeddingServices.FindAsync(idWeddingService);
            if (existingWeddingService == null)
                throw new ArgumentException($"Wedding Service with id {idWeddingService} not found");
            existingWeddingEvent.WeddingServices.Remove(existingWeddingService);
            _db.Update(existingWeddingEvent);
            await _db.SaveChangesAsync();
            return existingWeddingEvent;
        }
    }
}
