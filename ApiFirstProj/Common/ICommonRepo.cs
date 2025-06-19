using System.Linq.Expressions;

namespace ApiFirstProj.Common
{
    public interface ICommonRepo<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> condition, Func<IQueryable<T>, IQueryable<T>> query = null);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> condition = null, Func<IQueryable<T>, IQueryable<T>> query = null, CancellationToken cancellationToken = default);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity, params Expression<Func<T, object>>[] updateProperties);
        Task<bool> DeleteViaIdAsync(Guid id);
        Task<bool> DeleteViaCompKeyAsync(Expression<Func<T, bool>> condition);
    }
}
