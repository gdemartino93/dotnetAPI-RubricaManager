using System.Linq.Expressions;

namespace dotnetAPI_Rubrica.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, int pageSize = 0, int currentPage = 0);
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
