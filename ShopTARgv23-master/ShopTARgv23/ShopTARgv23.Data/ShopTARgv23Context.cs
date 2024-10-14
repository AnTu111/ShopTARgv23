using Microsoft.EntityFrameworkCore;
using ShopTARgv23.Core.Domain;

namespace ShopTARgv23.Data
{
    public class ShopTARgv23Context : DbContext
    {
        public ShopTARgv23Context(DbContextOptions<ShopTARgv23Context> options)
            : base(options) { }

        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToApi> FileToApis { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<FileToDatabase> FileToDatabases { get; set; }

    }
}
