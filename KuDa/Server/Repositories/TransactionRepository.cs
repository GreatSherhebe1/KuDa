using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;

namespace KuDa.Server.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private readonly AppDBContext appDBContext;

        public TransactionRepository(AppDBContext context)
        {
            appDBContext = context;
        }

        public Task Add(Transaction entity)
        {
            return Task.Run(() => 
            {
                appDBContext.Transactions.Add(entity);
                appDBContext.SaveChanges();
            });
        }

        public Task Delete(Transaction entity)
        {
            return Task.Run(() => 
            {
                appDBContext.Transactions.Remove(entity);
                appDBContext.SaveChanges();
            });
        }

        public Task<List<Transaction>> GetAll()
        {
            return Task.Run(() => appDBContext.Transactions.ToList());
        }

        public Task<Transaction> GetByID(int id)
        {
            return Task.Run(() => appDBContext.Transactions.FirstOrDefault(x => x.ID == id));
        }

        public Task Update(Transaction entity)
        {
            return Task.Run(() => 
            {
                appDBContext.Transactions.Update(entity);
                appDBContext.SaveChanges();
            });
        }
    }
}
