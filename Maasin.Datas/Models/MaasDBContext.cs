using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Maasin.Datas.Models
{
    public partial class MaasDBContext : DbContext
    {
        public MaasDBContext()
        {
        }

        public MaasDBContext(DbContextOptions<MaasDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserBranchMapping> UserBranchMapping { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.1.31;Database=MaasDB;User Id=sa; Password=Password1; MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Branch_pk")
                    .IsClustered(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("User_pk")
                    .IsClustered(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<UserBranchMapping>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("UserBranchMapping_pk")
                    .IsClustered(false);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.UserBranchMapping)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("UserBranchMapping_Branch_Id_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserBranchMapping)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("UserBranchMapping_User_Id_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
