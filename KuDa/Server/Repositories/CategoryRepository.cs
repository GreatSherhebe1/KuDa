using KuDa.Server.DBContext;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;
using System.Linq.Expressions;

namespace KuDa.Server.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly AppDBContext context;

        public CategoryRepository(AppDBContext context)
        {
            this.context = context;
        }

        public Task<Category?> GetByIDAsync(int id, CancellationToken token = default)
        {
            return Task.Run(() => context.Categories.FirstOrDefault(x => x.ID == id));
        }

        public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken token)
        {
            return await context.Categories.ToListAsync(token);
        }

        public async Task<IEnumerable<Category>> FindAsync(Expression<Func<Category, bool>> predicate, CancellationToken token)
        {
            return await context.Categories.Where(predicate).ToListAsync(token);
        }

        public Task AddAsync(Category entity, CancellationToken token = default)
        {
            return Task.Run(() => context.Categories.Add(entity), token);
        }

        public Task UpdateAsync(Category entity, CancellationToken token = default)
        {
            return Task.Run(() => context.Categories.Update(entity), token);
        }

        public Task Delete(Category entity)
        {
            return Task.Run(() => context.Categories.Remove(entity));
        }

        public Task SaveChangesAsync(CancellationToken token = default)
        {
            return Task.Run(context.SaveChanges, token);
        }
    }
}
