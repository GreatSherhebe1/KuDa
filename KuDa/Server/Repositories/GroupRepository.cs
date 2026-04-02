using KuDa.Server.DBContext;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interfaces;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace KuDa.Server.Repositories
{
    public class GroupRepository : IRepository<Model.Entities.Group>
    {
        private readonly AppDBContext context;

        public GroupRepository(AppDBContext context)
        {
            this.context = context;
        }


        public Task AddAsync(Model.Entities.Group entity, CancellationToken token = default)
        {
            return Task.Run(() => 
            {
                context.Groups.Add(entity);
                context.SaveChanges();
            });
        }

        public Task Delete(Model.Entities.Group entity)
        {
            return Task.Run(() => 
            {
                context.Groups.Remove(entity);
                context.SaveChanges();
            });
        }

        public Task<IEnumerable<Model.Entities.Group>> FindAsync(Expression<Func<Model.Entities.Group, bool>> predicate, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<List<Model.Entities.Group>> GetAllAsync()
        {
            return Task.Run(() => groups.ToList());
        }

        public async Task<IEnumerable<Model.Entities.Group>> GetAllAsync(CancellationToken token = default)
        {

            return await context.Groups.ToListAsync(token);
        }

        public Task<Model.Entities.Group?> GetByIDAsync(int id, CancellationToken token = default)
        {
            return Task.Run(() => context.Groups.FirstOrDefault(x => x.ID == id), token);
        }

        public Task UpdateAsync(Model.Entities.Group entity, CancellationToken token = default)
        {
            return Task.Run(() => 
            {
                context.Groups.Update(entity);
                context.SaveChanges();
            });
        }
    }
}
