using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class TestDbContext : DbContext
    {
		public DbSet<Cast> Casts { get; set; }

		public DbSet<Person> People { get; set; }

		public DbSet<Show> Shows { get; set; }
		public DbSet<Venue> Venues { get; set; }

		public TestDbContext(DbContextOptions options) : base(options)
        {
            

        }
       
    }
}
