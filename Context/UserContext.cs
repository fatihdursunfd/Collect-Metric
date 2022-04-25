using CollectMetrics.Model;
using Microsoft.EntityFrameworkCore;

namespace CollectMetrics.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
         public DbSet<User> User { get; set; }

    }
}