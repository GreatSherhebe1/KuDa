using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;

namespace KuDa.Server.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly DbSet<User> users;

        public UserRepository(AppDBContext context)
        {
            users = context.Users;
        }


        public Task Add(User entity)
        {
            return Task.Run(() => users.Add(entity));
        }

        public Task Delete(User entity)
        {
            return Task.Run(() => users.Remove(entity));
        }

        public Task<List<User>> GetAll()
        {
            return Task.Run(() => users.ToList());
        }

        public Task<User> GetByID(int id)
        {
            return Task.Run(() => users.FirstOrDefault(x => x.ID == id));
        }

        public Task Update(User entity)
        {
            return Task.Run(() => users.Update(entity));
        }
    }
}
