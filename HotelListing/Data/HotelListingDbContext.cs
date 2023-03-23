using Microsoft.EntityFrameworkCore;

public class HotelListingDbContext : DbContext
{
    public HotelListingDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Country>().HasData(
            new Country
            {
                Id = 1,
                Name = "United States",
                ShortName = "US"
            }, new Country
            {
                Id = 2,
                Name = "Brazil",
                ShortName = "BR"
            },
            new Country
            {
                Id = 3,
                Name = "China",
                ShortName = "CN"
            }
        );

        modelBuilder.Entity<Hotel>().HasData(
            new Hotel
            {
                Id = 1,
                Name = "Hotel 1",
                Address = "Address 1",
                CountryId = 1,
                Rating = 4
            });
    }
}