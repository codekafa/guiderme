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
        public DbSet<Service> Services { get; set; }
        public DbSet<ServicePhoto> ServicePhotos { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestProperty> RequestProperties { get; set; }
        public DbSet<ServiceRequestRelation> ServiceRequestRelations { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }

        public DbSet<OrderPaymentRequest> OrderPaymentRequests { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdateDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreateDate = DateTime.Now;
                    ((BaseEntity)entityEntry.Entity).IsActive = true;
                }
            }
            return base.SaveChanges();
        }
    }
}
