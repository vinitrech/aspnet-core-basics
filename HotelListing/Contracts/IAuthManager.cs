using HotelListing.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDTO userDTO);
        Task<bool> Login(LoginDTO loginDTO);
    }
}