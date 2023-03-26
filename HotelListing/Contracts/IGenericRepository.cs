using HotelListing.Models;

namespace HotelListing.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters);
        Task<T> AddASync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);

        Task<bool> Exists(int id);
    }
}