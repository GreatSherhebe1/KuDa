using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;

namespace KuDa.Server.Repositories
{
    public class GroupUserRepository : IRepository<GroupUser>
    {
        private readonly AppDBContext appDBContext;

        public GroupUserRepository(AppDBContext context)
        {
            appDBContext = context;
        }

        public Task Add(GroupUser entity)
        {
            return Task.Run(() =>
            {
                appDBContext.GroupsUsers.Add(entity);
                appDBContext.SaveChanges();
            });
        }

        public Task Delete(GroupUser entity)
        {
            return Task.Run(() => 
            {
                appDBContext.GroupsUsers.Remove(entity);
                appDBContext.SaveChanges();
            });
        }

        public Task<List<GroupUser>> GetAll()
        {
            return Task.Run(() => appDBContext.GroupsUsers.ToList());
        }

        public Task<GroupUser> GetByID(int id)
        {
            return Task.Run(() => appDBContext.GroupsUsers.FirstOrDefault(x => x.ID == id));
        }

        public Task Update(GroupUser entity)
        {
            return Task.Run(() => 
            {
                appDBContext.GroupsUsers.Update(entity);
                appDBContext.SaveChanges();
            });
        }
    }
}
