using CarRentalSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CarRentalSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            

        }

        public DbSet<Car> Cars { get; set; }

    }
}
