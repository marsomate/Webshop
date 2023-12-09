using CarStore.Models;
using Microsoft.EntityFrameworkCore;

namespace CarStore.DAL
{
    // This class represents the DbContext for interacting with the database.
    public class CarStoreDbContext : DbContext
    {
        // Constructor to initialize the DbContext with options.
        public CarStoreDbContext(DbContextOptions<CarStoreDbContext> options) : base(options) { }

        // DbSet property representing the collection of Car entities in the database.
        public DbSet<Car> Cars { get; set; }
    }
}
