using KuDa.Server.DBContext;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;
using System.Linq.Expressions;

namespace KuDa.Server.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private readonly AppDBContext context;

        public TransactionRepository(AppDBContext context) 
        {
            this.context = context;
        }

        public Task<Transaction?> GetByIDAsync(int id, CancellationToken token = default)
        {
            return Task.Run(() => context.Transactions.FirstOrDefault(x => x.ID == id), token);
        }
        public async Task<IEnumerable<Transaction>> GetAllAsync(CancellationToken token = default)
        {
            return await context.Transactions.ToListAsync(token);
        }
        public async Task<IEnumerable<Transaction>> FindAsync(Expression<Func<Transaction, bool>> predicate, CancellationToken token)
        {
            return await context.Transactions.Where(predicate).ToListAsync(token);
        }

        public Task AddAsync(Transaction entity, CancellationToken token = default)
        {
            return Task.Run(() => context.Transactions.Add(entity), token);
        }

        public Task UpdateAsync(Transaction entity, CancellationToken token = default)
        {
            return Task.Run(() => context.Transactions.Update(entity), token);
        }

        public Task Delete(Transaction entity)
        {
            return Task.Run(() => context.Transactions.Remove(entity));
        }

        public Task SaveChangesAsync(CancellationToken token = default)
        {
            return Task.Run(context.SaveChanges, token);
        }
    }
}
