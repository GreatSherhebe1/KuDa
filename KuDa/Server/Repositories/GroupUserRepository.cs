using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;

namespace KuDa.Server.Repositories
{
    public class GroupUserRepository : IRepository<GroupUser>
    {
        private readonly DbSet<GroupUser> groupUsers;

        public GroupUserRepository(AppDBContext context)
        {
            groupUsers = context.GroupUser;
        }

        public Task Add(GroupUser entity)
        {
            return Task.Run(() => groupUsers.Add(entity));
        }

        public Task Delete(GroupUser entity)
        {
            return Task.Run(() => groupUsers.Remove(entity));
        }

        public Task<List<GroupUser>> GetAll()
        {
            return Task.Run(() => groupUsers.ToList());
        }

        public Task<GroupUser> GetByID(int id)
        {
            return Task.Run(() => groupUsers.FirstOrDefault(x => x.ID == id));
        }

        public Task Update(GroupUser entity)
        {
            return Task.Run(() => groupUsers.Update(entity));
        }
    }
}
