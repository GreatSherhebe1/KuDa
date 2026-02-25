using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;

namespace KuDa.Server.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly AppDBContext appDBContext;

        public CategoryRepository(AppDBContext context) 
        {
            appDBContext = context;
        }

        public Task Add(Category entity)
        {
            return Task.Run(() => 
            {
                appDBContext.Categories.Add(entity);
                appDBContext.SaveChanges();
            });
        }

        public Task Delete(Category entity)
        {
            return Task.Run(() => 
            {
                appDBContext.Categories.Remove(entity);
                appDBContext.SaveChanges();
            });
        }

        public Task<List<Category>> GetAll()
        {
            return Task.Run(() => appDBContext.Categories.ToList());
        }

        public Task<Category> GetByID(int id)
        {
            return Task.Run(() => appDBContext.Categories.FirstOrDefault(x=> x.ID == id));
        }

        public Task Update(Category entity)
        {
            return Task.Run(() => 
            {
                appDBContext.Categories.Update(entity);
                appDBContext.SaveChanges();
            });
        }
    }
}
