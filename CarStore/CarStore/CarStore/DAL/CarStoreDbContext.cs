using CarStore.Models;
using Microsoft.EntityFrameworkCore;

namespace CarStore.DAL
{
    public class CarStoreDbContext : DbContext
    {
        public CarStoreDbContext(DbContextOptions<CarStoreDbContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
    }
}
