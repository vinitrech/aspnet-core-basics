using HotelListing.Core.Models;

namespace HotelListing.Core.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<TResult?> GetAsync<TResult>(int? id);

        Task<List<T>> GetAllAsync();
        Task<List<TResult>> GetAllAsync<TResult>();

        Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters);

        Task<T> AddASync(T entity);
        Task<TResult> AddASync<TSource, TResult>(TSource source);

        Task DeleteAsync(int id);

        Task UpdateAsync(T entity);
        Task UpdateAsync<TSource>(int id, TSource source);

        Task<bool> Exists(int id);
    }
}