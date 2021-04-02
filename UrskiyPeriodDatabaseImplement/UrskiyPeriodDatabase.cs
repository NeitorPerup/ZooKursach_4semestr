using Microsoft.EntityFrameworkCore;
using UrskiyPeriodDatabaseImplement.Models;

namespace UrskiyPeriodDatabaseImplement
{
    public class UrskiyPeriodDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-8LRKNM5V;Initial Catalog=UrskiyPeriodDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<User> Users { set; get; }

        public virtual DbSet<RouteUser> RouteUsers { set; get; }

        public virtual DbSet<Route> Routes { set; get; }

        public virtual DbSet<Payment> Payment { set; get; }

        public virtual DbSet<RouteReserve> RouteReserves { set; get; }

        public virtual DbSet<Reserve> Reserves { set; get; }
    }
}
