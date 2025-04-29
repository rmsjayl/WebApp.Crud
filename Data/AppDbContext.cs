using Microsoft.EntityFrameworkCore;
using WebApp.Crud.Models;

namespace WebApp.Crud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

    }
}
