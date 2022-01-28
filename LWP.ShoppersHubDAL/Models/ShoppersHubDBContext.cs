using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace LWP.ShoppersHubDAL.Models
{
    public partial class ShoppersHubDBContext : DbContext
    {
        public ShoppersHubDBContext()
        {
        }

        public ShoppersHubDBContext(DbContextOptions<ShoppersHubDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CardDetails> CardDetails { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<PurchaseDetails> PurchaseDetails { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var builder = new ConfigurationBuilder()
            //           .SetBasePath(Directory.GetCurrentDirectory())
            //           .AddJsonFile("appsettings.json");
            //var config = builder.Build();
            //var connectionString = config.GetConnectionString("ShoppersHubConnectionString");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;initial catalog=ShoppersHubDB;Integrated Security=true");
            }
                 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardDetails>(entity =>
            {
                entity.HasKey(e => e.CardNumber)
                    .HasName("pk_CardNumber");

                entity.Property(e => e.CardNumber).HasColumnType("numeric(16, 0)");

                entity.Property(e => e.Balance).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CardType)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cvvnumber)
                    .HasColumnName("CVVNumber")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.ExpiryDate).HasColumnType("date");

                entity.Property(e => e.NameOnCard)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("pk_CategoryId");

                entity.HasIndex(e => e.CategoryName)
                    .HasName("uq_CategoryName")
                    .IsUnique();

                entity.Property(e => e.CategoryId).ValueGeneratedOnAdd();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("pk_ProductId");

                entity.HasIndex(e => e.ProductName)
                    .HasName("uq_ProductName")
                    .IsUnique();

                entity.Property(e => e.ProductId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Price).HasColumnType("numeric(8, 0)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("fk_CategoryId");
            });

            modelBuilder.Entity<PurchaseDetails>(entity =>
            {
                entity.HasKey(e => e.PurchaseId)
                    .HasName("pk_PurchaseId");

                entity.Property(e => e.DateOfPurchase)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.EmailId)
                    .HasConstraintName("fk_EmailId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_ProductId");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("pk_RoleId");

                entity.HasIndex(e => e.RoleName)
                    .HasName("uq_RoleName")
                    .IsUnique();

                entity.Property(e => e.RoleId).ValueGeneratedOnAdd();

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("pk_EmailId");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("fk_RoleId");
            });

            modelBuilder.HasDbFunction(() => ShoppersHubDBContext.ufn_GenerateNewProductId());

            modelBuilder.HasDbFunction(() => ShoppersHubDBContext.ufn_GenerateNewCategoryId());

            modelBuilder.HasDbFunction(() => ShoppersHubDBContext.ufn_CheckEmailId());
        }
        public static string ufn_GenerateNewProductId()
        {
            return null;
        }

        public static int ufn_GenerateNewCategoryId()
        {
            return 0;
        }

        public static int ufn_CheckEmailId()
        {
            return 0;
        }
    }
}
