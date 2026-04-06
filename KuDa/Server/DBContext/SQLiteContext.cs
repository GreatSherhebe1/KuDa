using Microsoft.EntityFrameworkCore;

namespace KuDa.Server.DBContext
{
    public class SQLiteContext : AppDBContext
    {
        public SQLiteContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
    }
}
