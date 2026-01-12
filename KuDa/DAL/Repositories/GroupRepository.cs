using Model.Entities;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        public Task AddAsync(Group entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Group entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Group>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Group> GetByIDAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Group entity)
        {
            throw new NotImplementedException();
        }
    }
}
