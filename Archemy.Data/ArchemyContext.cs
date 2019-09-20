using System;
using Microsoft.EntityFrameworkCore;
using Archemy.Data.Pocos;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Archemy.Data
{
    public partial class ArchemyContext : DbContext
    {
        public ArchemyContext()
        {
        }

        public ArchemyContext(DbContextOptions<ArchemyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountSubType> AccountSubType { get; set; }
        public virtual DbSet<AccountType> AccountType { get; set; }
        public virtual DbSet<ActivityTimeLine> ActivityTimeLine { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<ContractItem> ContractItem { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Password> Password { get; set; }
        public virtual DbSet<Plan> Plan { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<ValueHelp> ValueHelp { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Password>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("Password_pkey");

                entity.Property(e => e.EmpId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ValueHelp>(entity =>
            {
                entity.HasKey(e => new { e.ValueType, e.ValueKey })
                    .HasName("ValueHelp_pkey");
            });
        }
    }
}
