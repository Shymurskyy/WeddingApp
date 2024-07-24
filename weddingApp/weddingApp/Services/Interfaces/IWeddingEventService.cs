using weddingApp.Model.Entities;

namespace weddingApp.Services.Interfaces
{
    public interface IWeddingEventService
    {
        Task<IEnumerable<WeddingEvent>> GetAllWeddingEvents();
        Task<WeddingEvent> GetWeddingEventById(int id );
        Task<WeddingEvent> CreateWeddingEvent(WeddingEvent weddingEvent);
        Task<WeddingEvent> UpdateWeddingEvent(WeddingEvent weddingEvent);
        Task<WeddingEvent> DeleteWeddingEvent(WeddingEvent weddingEvent);
        Task<WeddingEvent> AddGift(int idWeddingEvent, int idGift);
        Task<WeddingEvent> RemoveGift(int idWeddingEvent, int idGift);
        Task<WeddingEvent> AddGuest(int idWeddingEvent, int idGuest);
        Task<WeddingEvent> RemoveGuest(int idWeddingEvent, int idGuest);
        Task<WeddingEvent> AddWeddingService(int idWeddingEvent, int idWeddingService);
        Task<WeddingEvent> RemoveWeddingService(int idWeddingEvent, int idWeddingService);
    }
}
