using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication.Models
{
    public partial class CPC_Clone_dbContext : DbContext
    {
        public CPC_Clone_dbContext()
        {
        }

        public CPC_Clone_dbContext(DbContextOptions<CPC_Clone_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CurrencyTypes> CurrencyTypes { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<GenderTypes> GenderTypes { get; set; }
        public virtual DbSet<PettyCashRequests> PettyCashRequests { get; set; }
        public virtual DbSet<StatusTypes> StatusTypes { get; set; }
        public virtual DbSet<TransactionLogs> TransactionLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-6IMEBUR;Database=CPC_Clone_db;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyTypes>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasIndex(e => e.GenderTypeId);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.GenderType)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.GenderTypeId);
            });

            modelBuilder.Entity<GenderTypes>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<PettyCashRequests>(entity =>
            {
                entity.HasIndex(e => e.CurrencyTypeId);

                entity.HasIndex(e => e.EmployeeId);

                entity.HasIndex(e => e.StatusTypeId);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1500);

                entity.HasOne(d => d.CurrencyType)
                    .WithMany(p => p.PettyCashRequests)
                    .HasForeignKey(d => d.CurrencyTypeId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PettyCashRequests)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.StatusType)
                    .WithMany(p => p.PettyCashRequests)
                    .HasForeignKey(d => d.StatusTypeId);
            });

            modelBuilder.Entity<StatusTypes>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<TransactionLogs>(entity =>
            {
                entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Credit).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
