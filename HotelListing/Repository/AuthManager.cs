using AutoMapper;
using HotelListing.Contracts;
using HotelListing.Data;
using HotelListing.Data.Configurations;
using HotelListing.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.Repository
{

    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;

        public AuthManager(IMapper mapper, UserManager<ApiUser> userManager)
        {
            this._mapper = mapper;
            this._userManager = userManager;
        }

        public async Task<bool> Login(LoginDTO loginDTO)
        {

            bool isValidUser = false;

            try
            {
                var user = await _userManager.FindByEmailAsync(loginDTO.Email);

                if (user is null)
                {
                    return default;
                }

                bool isValidCredentials = await _userManager.CheckPasswordAsync(user, loginDTO.Password);

                if (!isValidCredentials)
                {
                    return default;
                }
            }
            catch (Exception)
            {

            }

            return isValidUser;
        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUserDTO userDTO)
        {
            var user = _mapper.Map<ApiUser>(userDTO);

            user.UserName = userDTO.Email;

            var result = await _userManager.CreateAsync(user, userDTO.Password); // password gets hashed in this step

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, ApiRoles.User);
            }

            return result.Errors;
        }
    }
}