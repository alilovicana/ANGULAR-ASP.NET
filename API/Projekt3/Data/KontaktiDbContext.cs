using Microsoft.EntityFrameworkCore;
using Projekt3.Models;

namespace Projekt3.Data
{
    public class KontaktiDbContext : DbContext
    {
        public KontaktiDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Kontakt> Kontakti { get; set; }
    }
}






