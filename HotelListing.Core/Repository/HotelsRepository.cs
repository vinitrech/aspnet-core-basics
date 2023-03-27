using AutoMapper;
using HotelListing.Core.Contracts;
using HotelListing.Data;

namespace HotelListing.Core.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        public HotelsRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}