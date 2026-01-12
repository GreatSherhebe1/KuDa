using Model.Entities;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GroupUserRepository : IRepository<GroupUser>
    {
        public Task AddAsync(GroupUser entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(GroupUser entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GroupUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GroupUser> GetByIDAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(GroupUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
