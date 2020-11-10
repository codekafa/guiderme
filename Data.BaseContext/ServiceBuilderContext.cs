using DataModel.BaseEntities;
using DataModel.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Data.BaseContext
{
    public class ServiceBuilderContext : DbContext
    {

        public ServiceBuilderContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<OtpTransaction> OtpTransactions { get; set; }
        public DbSet<ServiceCategoryProperty> ServiceCategoryProperties { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Lexicon> Lexicons { get; set; }
        public DbSet<ExceptionLog> ExceptionLog { get; set; }
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdateDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreateDate = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
