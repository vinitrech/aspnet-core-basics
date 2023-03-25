using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
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
        }
    }
}