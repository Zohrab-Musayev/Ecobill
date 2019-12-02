using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EcoBill.Models
{
    public partial class EcobillDbContext : DbContext
    {
        public EcobillDbContext()
        {
        }

        public EcobillDbContext(DbContextOptions<EcobillDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCard> ProductCard { get; set; }
        public virtual DbSet<ShoppingCard> ShoppingCard { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EcobillDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductCard>(entity =>
            {
                entity.ToTable("Product_Card");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.ShoppingCardId).HasColumnName("Shopping_Card_Id");
            });

            modelBuilder.Entity<ShoppingCard>(entity =>
            {
                entity.ToTable("Shopping_Card");
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("Total_Price")
                    .HasMaxLength(10);

                entity.Property(e => e.UserId).HasColumnName("User_Id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.QrCode).HasMaxLength(50);

                entity.Property(e => e.UniqueCode).HasMaxLength(50);
            });
        }
    }
}
