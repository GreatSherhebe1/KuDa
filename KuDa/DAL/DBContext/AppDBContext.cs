using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace DAL.DBContext
{
    public class AppDBContext : DbContext
    {
        private readonly string connectionString;
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupUser> GroupUsers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public AppDBContext(string connectionString) 
        {
            this.connectionString = connectionString;
            Database.EnsureCreated();
        }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
