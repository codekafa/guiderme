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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> users { get; set; }
        public DbSet<UserAddress> userAddresses { get; set; }
        public DbSet<OtpTransaction> otptransactions { get; set; }
        public DbSet<ServiceCategoryProperty> servicecategoryproperties { get; set; }
        public DbSet<ServiceCategory> servicecategories { get; set; }
        public DbSet<Page> pages { get; set; }
        public DbSet<Lexicon> lexicons { get; set; }
        public DbSet<ExceptionLog> exceptionlog { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<ServicePhoto> servicephotos { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Request> requests { get; set; }
        public DbSet<RequestProperty> requestproperties { get; set; }
        public DbSet<ServiceRequestRelation> servicerequestrelations { get; set; }
        public DbSet<Gallery> galleries { get; set; }
        public DbSet<PaymentTransaction> paymenttransactions { get; set; }

        public DbSet<OrderPaymentRequest> orderpaymentrequests { get; set; }

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
