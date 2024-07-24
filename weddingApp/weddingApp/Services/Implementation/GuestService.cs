using Microsoft.EntityFrameworkCore;
using weddingApp.Data;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Services.Implementation
{
    public class GuestService : IGuestService
    {
        private readonly IConfiguration _configuration;
        private readonly WeddingAppContext _db;
        public GuestService(IConfiguration configuration, WeddingAppContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        public async Task<IEnumerable<Guest>> GetAllGuests()
        {
            Task<List<Guest>>? guests = _db.Guests.ToListAsync();
            return await guests;

        }
        public async Task<Guest> GetGuestById(int id)
        {
            Guest? guest = await _db.Guests.FirstOrDefaultAsync(x => x.Id == id);
            return guest;
        }
        public async Task<Guest> CreateGuest(Guest guest)
        {
            _db.Guests.Add(guest);
            await _db.SaveChangesAsync();
            return guest;
        }

        public async Task<Guest> UpdateGuest(Guest guest)
        {
            var existingGuest = _db.Guests.FirstOrDefault(x => x.Id == guest.Id);
            if (existingGuest != null)
                throw new ArgumentException($"Guest with id {existingGuest.Id} not found");
            
            existingGuest.FirstName = guest.FirstName;
            existingGuest.LastName = guest.LastName;
            existingGuest.Email = guest.Email;
            existingGuest.Phone = guest.Phone;
            existingGuest.AccompanyingPerson = guest.AccompanyingPerson;
            existingGuest.InviteSended = guest.InviteSended;

            _db.Update(existingGuest);
            await _db.SaveChangesAsync();
            return existingGuest;
        }
        public async Task<Guest> DeleteGuest(Guest guest)
        {
            _db.Guests.Remove(guest);
            await _db.SaveChangesAsync();
            return guest;
        }
    }
}
