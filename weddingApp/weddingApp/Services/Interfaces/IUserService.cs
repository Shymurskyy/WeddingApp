using weddingApp.Model.Entities;

namespace weddingApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Authenticate(string login, string password);
        Task<User> CreateUserAsync(User user);
    }
}