using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TenantPropertyMngt.Models;
namespace TenantPropertyMngt.Data
{
    public class TenantPropertyMngtDbContext : IdentityDbContext<ApplicationUser>
    {
        public TenantPropertyMngtDbContext(DbContextOptions<TenantPropertyMngtDbContext> options) : base(options)
        {
        }
        public DbSet<PropertyModel> Properties { get; set; }
        public DbSet<PropertyOwnerModel> PropertiesOwners { get; set; }
        
        public DbSet<TenantModel> Tenants { get; set; }

        public DbSet<LeaseModel> Leases { get; set; }
        public DbSet<RentPaymentModel> RentPayments { get; set; }
        public DbSet<MaintenanceModel>Maintenances { get; set; }
        public DbSet<ContractorsModel> Contractors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var agent = new IdentityRole("agent");
            agent.NormalizedName = "agent";

            var tenant = new IdentityRole("tenant");
            tenant.NormalizedName = "tenant";

            modelBuilder.Entity<IdentityRole>().HasData(admin, agent, tenant);

            modelBuilder.Entity<LeaseModel>()
                .HasOne(l => l.Tenant)
                .WithMany(t => t.lease)  // Corrected property name here (t.leases)
                .HasForeignKey(l => l.TenantID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LeaseModel>()
                .HasOne(l => l.Properties)
                .WithMany(p => p.Leases)
                .HasForeignKey(l => l.PropertyID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TenantModel>()
                .HasMany(t => t.AssociatedProperty)
                .WithMany(p => p.Tenants)
                .UsingEntity(j => j.ToTable("TenantProperty"));

            modelBuilder.Entity<LeaseModel>()
                .Property(l => l.Rent)
                .HasColumnType("decimal(18,0)");  // Corrected precision and scale for Rent property

            modelBuilder.Entity<PropertyModel>()
                .Property(p => p.Rent)
                .HasColumnType("decimal(18,0)");  // Corrected precision and scale for Rent property
        }

    }
}
