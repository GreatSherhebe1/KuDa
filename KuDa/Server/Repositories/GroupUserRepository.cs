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
            return Task.Run(() => context.GroupUser.FirstOrDefault(x => x.ID == id), token);
        }

        public async Task<IEnumerable<GroupUser>> GetAllAsync(CancellationToken token = default)
        {
            return await context.GroupUser.ToListAsync(token);
        }

        public async Task<IEnumerable<GroupUser>> FindAsync(Expression<Func<GroupUser, bool>> predicate, CancellationToken token)
        {
            return await context.GroupUser.Where(predicate).ToListAsync(token);
        }

        public Task AddAsync(GroupUser entity, CancellationToken token = default)
        {
            return Task.Run(() => 
            {
                context.GroupUser.Add(entity);
                context.SaveChanges();
            }, token);
        }

        public Task UpdateAsync(GroupUser entity, CancellationToken token = default)
        {
            return Task.Run(() => 
            {
                context.GroupUser.Update(entity);
                context.SaveChanges();
            }, token);
        }

        public Task Delete(GroupUser entity)
        {
            return Task.Run(() =>
            {
                context.GroupUser.Remove(entity);
                context.SaveChanges();
            }); 
        }
    }
}
