using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Settlements> Settlements { get; set; } = null!;
    }
}
