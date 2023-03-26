using AutoMapper;
using HotelListing.Contracts;
using HotelListing.Data;

namespace HotelListing.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        public HotelsRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}