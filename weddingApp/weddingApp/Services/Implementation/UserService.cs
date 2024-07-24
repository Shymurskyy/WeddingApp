using Microsoft.EntityFrameworkCore;
using weddingApp.Data;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;

namespace weddingApp.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly WeddingAppContext _context;
        public UserService(WeddingAppContext context)
        {
            _context = context;
        }
        public async Task<User> Authenticate(string login, string password)
        {
            User? user = await _context.Users.SingleOrDefaultAsync(x => x.Email == login);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                return null;
            return user;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.CreateTime = DateTime.UtcNow;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
