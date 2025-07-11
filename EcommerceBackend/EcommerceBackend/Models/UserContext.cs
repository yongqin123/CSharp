using Microsoft.EntityFrameworkCore;

namespace EcommerceBackend.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {
        }

        protected UserContext()
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
