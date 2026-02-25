using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;

namespace KuDa.Server.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDBContext appDBContext;

        public UserRepository(AppDBContext context)
        {
            appDBContext = context;
        }


        public Task Add(User entity)
        {
            return Task.Run(() => 
            {
                appDBContext.Users.Add(entity);
                appDBContext.SaveChanges();
            });
        }

        public Task Delete(User entity)
        {
            return Task.Run(() => 
            {
                appDBContext.Users.Remove(entity);
                appDBContext.SaveChanges();
            });
        }

        public Task<List<User>> GetAll()
        {
            return Task.Run(() => appDBContext.Users.ToList());
        }

        public Task<User> GetByID(int id)
        {
            return Task.Run(() => appDBContext.Users.FirstOrDefault(x => x.ID == id));
        }

        public Task Update(User entity)
        {
            return Task.Run(() => 
            { 
                appDBContext.Users.Update(entity); 
                appDBContext.SaveChanges(); 
            });
        }
    }
}
