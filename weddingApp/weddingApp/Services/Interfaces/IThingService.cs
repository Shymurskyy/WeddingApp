using Microsoft.AspNetCore.Mvc;
using weddingApp.Model.DTO_s;
using weddingApp.Model.Entities;

namespace weddingApp.Services.Interfaces
{
    public interface IThingService
    {
        Task<IEnumerable<Thing>> GetAllThings();
        Task<Thing> GetThingById(int id);
        Task<Thing> CreateThing(Thing thing);
        Task<Thing> UpdateThing(Thing thing);
        Task<Thing> DeleteThing(Thing thing);

    }
}
