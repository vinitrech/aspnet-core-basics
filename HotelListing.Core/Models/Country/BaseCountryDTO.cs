using System.ComponentModel.DataAnnotations;

namespace HotelListing.Core.Models.Country
{
    public abstract class BaseCountryDTO
    {
        [Required] // validation doesnt matter when getting data, so there is no problem adding to the base dto
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}