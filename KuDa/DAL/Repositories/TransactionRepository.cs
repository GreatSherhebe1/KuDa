using Model.Entities;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        public Task AddAsync(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Transaction entity)
    {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetByIDAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Transaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
