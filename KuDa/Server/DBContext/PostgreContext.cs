using Microsoft.EntityFrameworkCore;

namespace KuDa.Server.DBContext
{
    public class PostgreContext : AppDBContext
    {
        public PostgreContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
    }
}
