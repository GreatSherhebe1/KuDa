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

        public Task Add(Group entity)
        {
            return Task.Run(() => groups.Add(entity));
        }

        public Task Delete(Group entity)
        {
            return Task.Run(() => groups.Remove(entity));
        }

        public Task<List<Group>> GetAll()
        {
            return Task.Run(() => groups.ToList());
        }

        public Task<Group> GetByID(int id)
        {
            return Task.Run(() => groups.FirstOrDefault(x => x.ID == id));
        }

        public Task Update(Group entity)
        {
            return Task.Run(() => groups.Update(entity));
        }
    }
}
