using Microsoft.EntityFrameworkCore;
using MyWebApp.Database.Models;

namespace MyWebApp.Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Entity1> Entities1 { get; set; }
    }
}
