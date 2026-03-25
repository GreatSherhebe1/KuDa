using KuDa.Server.DBContext;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;

namespace KuDa.Server.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private readonly DbSet<Transaction> transactions;

        public TransactionRepository(AppDBContext context)
        {
            transactions = context.Transactions;
        }

        public Task Add(Transaction entity)
        {
            return Task.Run(() => transactions.Add(entity));
        }

        public Task Delete(Transaction entity)
        {
            return Task.Run(() => transactions.Remove(entity));
        }

        public Task<List<Transaction>> GetAll()
        {
            return Task.Run(() => transactions.ToList());
        }

        public Task<Transaction> GetByID(int id)
        {
            return Task.Run(() => transactions.FirstOrDefault(x => x.ID == id));
        }

        public Task Update(Transaction entity)
        {
            return Task.Run(() => transactions.Update(entity));
        }
    }
}
