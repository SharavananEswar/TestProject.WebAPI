using Microsoft.EntityFrameworkCore;
using ZipPay.Model;

namespace ZipPay.EF.MySQLProvider
{
    public class ZipPayEFContext : DbContext
    {
        public ZipPayEFContext(DbContextOptions<ZipPayEFContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<UserAccount>()
                .HasKey(e => e.Id);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}