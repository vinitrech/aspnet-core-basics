using AutoMapper;
using HotelListing.Data;
using HotelListing.Models.Country;
using HotelListing.Models.Hotel;
using HotelListing.Models.Users;

namespace HotelListing.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, GetCountryDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, UpdateCountryDTO>().ReverseMap();

            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();

            CreateMap<ApiUserDTO, ApiUser>().ReverseMap();
        }
    }
}