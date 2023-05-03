using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository_DL.DBModels;

public partial class BarterDbContext : DbContext
{
    public BarterDbContext()
    {
    }

    public BarterDbContext(DbContextOptions<BarterDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ServiceToCraftsmanTbl> ServiceToCraftsmanTbls { get; set; }

    public virtual DbSet<ServiceToCustomerTbl> ServiceToCustomerTbls { get; set; }

    public virtual DbSet<ServiceTypeTbl> ServiceTypeTbls { get; set; }

    public virtual DbSet<UsersTbl> UsersTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=PC;Initial Catalog=Barter_DB;Integrated Security=True;trustserverCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ServiceToCraftsmanTbl>(entity =>
        {
            entity.HasKey(e => new { e.IdCraftsman, e.IdTypeService });

            entity.ToTable("ServiceToCraftsman_tbl");

            entity.Property(e => e.IdTypeService).HasColumnName("idTypeService");

            entity.HasOne(d => d.IdCraftsmanNavigation).WithMany(p => p.ServiceToCraftsmanTbls)
                .HasForeignKey(d => d.IdCraftsman)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceToCraftsman_tbl_Users_tbl");

            entity.HasOne(d => d.IdTypeServiceNavigation).WithMany(p => p.ServiceToCraftsmanTbls)
                .HasForeignKey(d => d.IdTypeService)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceToCraftsman_tbl_ServiceType_tbl");
        });

        modelBuilder.Entity<ServiceToCustomerTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ServiceToCustomer");

            entity.ToTable("ServiceToCustomer_tbl");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.NumHours)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ServiceToCustomerTbl)
                .HasForeignKey<ServiceToCustomerTbl>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceToCustomer_tbl_Users_tbl");
        });

        modelBuilder.Entity<ServiceTypeTbl>(entity =>
        {
            entity.HasKey(e => e.IdService);

            entity.ToTable("ServiceType_tbl");

            entity.Property(e => e.IdService).ValueGeneratedNever();
            entity.Property(e => e.NameService).HasMaxLength(50);
        });

        modelBuilder.Entity<UsersTbl>(entity =>
        {
            entity.ToTable("Users_tbl");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.NameUser).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Web).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
