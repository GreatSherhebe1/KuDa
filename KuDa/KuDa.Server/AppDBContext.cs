using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace KuDa.Server
{
    public class AppDBContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupUser> GroupUser { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { ID = 0, Email = "test@mail.ru", Name = "TestIvan"  });
        }
    }
}
