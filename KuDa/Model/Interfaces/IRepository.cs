using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IRepository<T>
    {
        Task<T?> GetByIDAsync(int id, CancellationToken token = default);
        Task<IEnumerable<T>> GetAllAsync (CancellationToken token = default);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken token);
        Task AddAsync(T entity, CancellationToken token = default);
        Task UpdateAsync(T entity, CancellationToken token = default);
        Task Delete(T entity);
    }
}
