using Microsoft.EntityFrameworkCore;
using weddingApp.Model.Entities;

namespace weddingApp.Data
{
    public class WeddingAppContext :DbContext
    {
        public WeddingAppContext(DbContextOptions<WeddingAppContext> option): base(option) { }
        public DbSet<Couple> Couples { get; set; }
        public DbSet<WeddingEvent> WeddingEvents { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<WeddingService> WeddingServices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Thing> Things { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
