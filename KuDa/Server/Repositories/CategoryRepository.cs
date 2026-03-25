using KuDa.Server.DBContext;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;

namespace KuDa.Server.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly DbSet<Category> categories;

        public CategoryRepository(AppDBContext context) 
        {
            categories = context.Categories;
        }

        public Task Add(Category entity)
        {
            return Task.Run(() => categories.Add(entity));
        }

        public Task Delete(Category entity)
        {
            return Task.Run(() => categories.Remove(entity));
        }

        public Task<List<Category>> GetAll()
        {
            return Task.Run(() => categories.ToList());
        }

        public Task<Category> GetByID(int id)
        {
            return Task.Run(() => categories.FirstOrDefault(x=> x.ID == id));
        }

        public Task Update(Category entity)
        {
            return Task.Run(() => 
            {
                categories.Update(entity);
            });
        }
    }
}
