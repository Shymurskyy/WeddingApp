using weddingApp.Model.Entities;

namespace weddingApp.Services.Interfaces
{
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> GetAllGuests();
        Task<Guest> GetGuestById(int id);
        Task<Guest> CreateGuest(Guest guest);
        Task<Guest> UpdateGuest(Guest guest);
        Task<Guest> DeleteGuest(Guest guest);
    }
}
