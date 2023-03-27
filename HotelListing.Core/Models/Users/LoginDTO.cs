using System.ComponentModel.DataAnnotations;

namespace HotelListing.Core.Models.Users
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Your password must be at least {2} characters long, and maximum {1}.", MinimumLength = 6)]
        public string Password { get; set; }
    }
}