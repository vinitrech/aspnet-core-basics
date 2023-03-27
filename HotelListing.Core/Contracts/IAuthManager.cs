using HotelListing.Core.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.Core.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDTO userDTO);
        Task<AuthResponseDTO> Login(LoginDTO loginDTO);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDTO> VerifyRefreshToken(AuthResponseDTO authResponseDTO);
    }
}