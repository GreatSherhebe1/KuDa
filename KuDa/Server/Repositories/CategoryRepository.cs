using KuDa.Server.DBContext;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;
using System.Linq.Expressions;

namespace KuDa.Server.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly DbSet<Category> categories;
        private readonly AppDBContext appDBContext;

        public CategoryRepository(AppDBContext context)
        {
            appDBContext = context;
            categories = context.Categories;
        }

        public Task<Category?> GetByIDAsync(int id, CancellationToken token = default)
        {
            return Task.Run(() => categories.FirstOrDefault(x => x.ID == id));
        }

        public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken token)
        {
            return await categories.ToListAsync(token);
        }

        public async Task<IEnumerable<Category>> FindAsync(Expression<Func<Category, bool>> predicate, CancellationToken token)
        {
            return await categories.Where(predicate).ToListAsync(token);
        }

        public Task AddAsync(Category entity, CancellationToken token = default)
        {
            return Task.Run(() => 
            { 
                categories.Add(entity);
                appDBContext.SaveChanges();
            }, token);
        }

        public Task UpdateAsync(Category entity, CancellationToken token = default)
        {
            return Task.Run(() => 
            {
                categories.Update(entity);
                appDBContext.SaveChanges();
            }, token);
        }

        public Task Delete(Category entity)
        {
            return Task.Run(() =>
            {
                categories.Remove(entity);
                appDBContext.SaveChanges();
            });
        }
    }
}
