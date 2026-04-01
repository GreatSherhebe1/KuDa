using KuDa.Server.DBContext;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;

namespace KuDa.Server.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        private readonly DbSet<Group> groups;

        public GroupRepository(AppDBContext context)
        {
            groups = context.Groups;
        }

        public Task AddAsync(Group entity)
        {
            return Task.Run(() => groups.Add(entity));
        }

        public Task Delete(Group entity)
        {
            return Task.Run(() => groups.Remove(entity));
        }

        public Task<List<Group>> GetAllAsync()
        {
            return Task.Run(() => groups.ToList());
        }

        public Task<Group> GetByIDAsync(int id)
        {
            return Task.Run(() => groups.FirstOrDefault(x => x.ID == id));
        }

        public Task Update(Group entity)
        {
            return Task.Run(() => groups.Update(entity));
        }
    }
}
