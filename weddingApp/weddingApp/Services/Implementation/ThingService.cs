using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using weddingApp.Data;
using weddingApp.Model.DTO_s;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Services.Implementation
{
    public class ThingService : IThingService
    {
        private readonly IConfiguration _configuration;
        private readonly WeddingAppContext _db;
        public ThingService(IConfiguration configuration, WeddingAppContext db)
        {
            _configuration = configuration;
            _db = db;
        }
        public async Task<IEnumerable<Thing>> GetAllThings()
        {
            Task<List<Thing>>? things = _db.Things.ToListAsync();
            return await things;
        }
        public async Task<Thing> GetThingById(int id)
        {
            Task<Thing?>? thing = _db.Things.FirstOrDefaultAsync(x => x.Id == id);
            return await thing;
        }
        public async Task<Thing> CreateThing(Thing thing)
        {
            _db.Things.Add(thing);
            await _db.SaveChangesAsync();
            return thing;
        }
        public async Task<Thing> UpdateThing(Thing thing)
        {
            Thing? existingThing = await _db.Things.FindAsync(thing.Id);

            if (existingThing == null)
                throw new ArgumentException($"Thing with id {thing.Id} not found");

            existingThing.Name = thing.Name;
            existingThing.Description = thing.Description;
            existingThing.Gift = thing.Gift;
            _db.Things.Update(existingThing);
            await _db.SaveChangesAsync();

            return existingThing;
        }

        public async Task<Thing> DeleteThing(Thing thing)
        {
            _db.Things.Remove(thing);
            await _db.SaveChangesAsync();
            return thing;
        }

        public async Task<Thing> DeleteGetThingByIdAsyncThing(Thing thing)
        {
            _db.Things.Remove(thing);
            await _db.SaveChangesAsync();
            return thing;

        }
    }
}
