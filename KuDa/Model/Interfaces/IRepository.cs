using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetByIDAsync(int id, CancellationToken token = default);
        Task<List<T>> GetAllAsync(CancellationToken token = default);
        Task AddAsync(T entity, CancellationToken token = default);
        Task UpdateAsync(T entity, CancellationToken token = default);
        Task Delete(T entity);
        Task SaveChangesAsync(CancellationToken token = default);
    }
}
