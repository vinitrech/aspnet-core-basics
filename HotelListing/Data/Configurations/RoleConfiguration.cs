using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole { Name = ApiRoles.Admin, NormalizedName = ApiRoles.ADMINISTRATOR },
                new IdentityRole { Name = ApiRoles.User, NormalizedName = ApiRoles.USER }
            );
        }
    }
}