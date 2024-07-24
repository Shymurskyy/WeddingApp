using weddingApp.Model.Entities;

namespace weddingApp.Services.Security
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}