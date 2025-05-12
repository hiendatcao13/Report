using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC2.Models;

public partial class QlsinhVienContext : DbContext
{
    private readonly IConfiguration _configuration;

    public QlsinhVienContext(DbContextOptions<QlsinhVienContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    public virtual DbSet<SinhVienTemp> SinhVienTemps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.MaKhoa).HasName("PK__Khoa__653904052B9DE591");

            entity.ToTable("Khoa");

            entity.Property(e => e.MaKhoa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenKhoa).HasMaxLength(100);
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.MaLop).HasName("PK__Lop__3B98D273DA4165A2");

            entity.ToTable("Lop");

            entity.Property(e => e.MaLop)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaKhoa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenLop).HasMaxLength(100);

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.Lops)
                .HasForeignKey(d => d.MaKhoa)
                .HasConstraintName("FK__Lop__MaKhoa__398D8EEE");
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.MaSinhVien).HasName("PK__SinhVien__939AE775412FFF66");

            entity.ToTable("SinhVien", tb => tb.HasTrigger("trg_Insert_SinhVien"));

            entity.Property(e => e.MaSinhVien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.MaLop)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.MaLopNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.MaLop)
                .HasConstraintName("FK__SinhVien__MaLop__3C69FB99");
        });

        modelBuilder.Entity<SinhVienTemp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SinhVienTemp");

            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.MaLop)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaSinhVien)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
