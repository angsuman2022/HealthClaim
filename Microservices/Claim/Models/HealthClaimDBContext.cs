using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Claim.Models
{
    public partial class HealthClaimDBContext : DbContext
    {
        public HealthClaimDBContext()
        {
        }

        public HealthClaimDBContext(DbContextOptions<HealthClaimDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Claimtbl> Claimtbls { get; set; }
        public virtual DbSet<Logtbl> Logtbls { get; set; }
        public virtual DbSet<MemberDet> MemberDets { get; set; }
        public virtual DbSet<PhysicianDet> PhysicianDets { get; set; }
        public virtual DbSet<Statetbl> Statetbls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Claimtbl>(entity =>
            {
                entity.HasKey(e => e.ClaimId);

                entity.ToTable("Claimtbl");

                entity.Property(e => e.ClaimId).HasColumnName("ClaimID");

                entity.Property(e => e.ClaimAmount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ClaimDate).HasColumnType("datetime");

                entity.Property(e => e.ClaimType).HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(100);
            });

            modelBuilder.Entity<Logtbl>(entity =>
            {
                entity.HasKey(e => e.Slno);

                entity.ToTable("Logtbl");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ErrorMsg).HasMaxLength(1000);
            });

            modelBuilder.Entity<MemberDet>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("MemberDet");

                entity.HasIndex(e => e.UserName, "UQ__MemberDe__C9F2845627BA75A2")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.ConPassword).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MemberType).HasMaxLength(50);

                entity.Property(e => e.ModiDate).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PhysicianDet>(entity =>
            {
                entity.HasKey(e => e.PhysicianId);

                entity.ToTable("PhysicianDet");

                entity.Property(e => e.PhysicianName).HasMaxLength(50);

                entity.Property(e => e.PhysicianState).HasMaxLength(50);
            });

            modelBuilder.Entity<Statetbl>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.ToTable("Statetbl");

                entity.Property(e => e.StateName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
