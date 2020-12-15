using Microsoft.EntityFrameworkCore;
using password_manager.Entities;

namespace password_manager.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Login> Logins { get; set; }
        public DbSet<Auth> Auths { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=/home/hugovallada/Data/psm.db");

    }
}