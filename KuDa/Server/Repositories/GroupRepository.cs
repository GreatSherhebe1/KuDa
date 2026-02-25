using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;

namespace KuDa.Server.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        private readonly AppDBContext appDBContext;

        public GroupRepository(AppDBContext context)
        {
            appDBContext = context;
        }

        public Task Add(Group entity)
        {
            return Task.Run(() => 
            {
                appDBContext.Add(entity);
                appDBContext.SaveChanges();
            });
        }

        public Task Delete(Group entity)
        {
            return Task.Run(() => 
            {
                appDBContext.Groups.Remove(entity);
                appDBContext.SaveChanges();
            });
        }

        public Task<List<Group>> GetAll()
        {
            return Task.Run(() => appDBContext.Groups.ToList());
        }

        public Task<Group> GetByID(int id)
        {
            return Task.Run(() => appDBContext.Groups.FirstOrDefault(x => x.ID == id));
        }

        public Task Update(Group entity)
        {
            return Task.Run(() => 
            {
                appDBContext.Groups.Update(entity);
                appDBContext.SaveChanges();
            });
        }
    }
}
