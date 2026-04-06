using KuDa.Server.DBContext;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;
using System.Linq.Expressions;

namespace KuDa.Server.Repositories
{
    public class GroupUserRepository : IRepository<GroupUser>
    {
        private readonly AppDBContext context;

        public GroupUserRepository(AppDBContext context)
        {
            this.context = context;
        }

        public Task<GroupUser?> GetByIDAsync(int id, CancellationToken token = default)
        {
            return Task.Run(() => context.GroupsUsers.FirstOrDefault(x => x.ID == id), token);
        }

        public async Task<IEnumerable<GroupUser>> GetAllAsync(CancellationToken token = default)
        {
            return await context.GroupsUsers.ToListAsync(token);
        }

        public async Task<IEnumerable<GroupUser>> FindAsync(Expression<Func<GroupUser, bool>> predicate, CancellationToken token)
        {
            return await context.GroupsUsers.Where(predicate).ToListAsync(token);
        }

        public Task AddAsync(GroupUser entity, CancellationToken token = default)
        {
            return Task.Run(() => context.GroupsUsers.Add(entity), token);
        }

        public Task UpdateAsync(GroupUser entity, CancellationToken token = default)
        {
            return Task.Run(() => context.GroupsUsers.Update(entity), token);
        }

        public Task Delete(GroupUser entity)
        {
            return Task.Run(() => context.GroupsUsers.Remove(entity)); 
        }

        public Task SaveChangesAsync(CancellationToken token = default)
        {
            return Task.Run(context.SaveChanges, token);
        }
    }
}
