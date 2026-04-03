using KuDa.Server.DBContext;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;
using System.Linq.Expressions;

namespace KuDa.Server.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDBContext context;

        public UserRepository(AppDBContext context)
        {
            this.context = context;
        }

        public Task<User?> GetByIDAsync(int id, CancellationToken token = default)
        {
            return Task.Run(() => context.Users.FirstOrDefault(x => x.ID == id), token);
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken token = default)
        {
            return await context.Users.ToListAsync(token);
        }

        public async Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate, CancellationToken token)
        {
            return await context.Users.Where(predicate).ToListAsync(token);
        }

        public Task AddAsync(User entity, CancellationToken token = default)
        {
            return Task.Run(() => context.Users.Add(entity), token);
        }

        public Task UpdateAsync(User entity, CancellationToken token = default)
        {
            return Task.Run(() => context.Users.Update(entity), token);
        }

        public Task Delete(User entity)
        {
            return Task.Run(() => context.Users.Remove(entity));
        }

        public Task SaveChangesAsync(CancellationToken token = default)
        {
            return Task.Run(context.SaveChanges, token);
        }
    }
}
