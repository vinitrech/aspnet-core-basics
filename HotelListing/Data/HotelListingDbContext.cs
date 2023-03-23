using Microsoft.EntityFrameworkCore;

public class HotelListingDbContext : DbContext
{
    public HotelListingDbContext(DbContextOptions options) : base(options)
    {

    }
}