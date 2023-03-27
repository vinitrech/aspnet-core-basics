using HotelListing.Core.Models.Hotel;

namespace HotelListing.Core.Models.Country
{
    public class CountryDTO : BaseCountryDTO
    {
        public int Id { get; set; }
        public List<HotelDTO> Hotels { get; set; }
    }
}