using Microsoft.EntityFrameworkCore;

namespace MVC2.Models_CF
{
    public class QLNhanVienContext :DbContext
    {
        public QLNhanVienContext(DbContextOptions<QLNhanVienContext> options) : base(options)
        {
        }
        public DbSet<NhanVien> NhanViens { get; set; } = null!;
        public DbSet<PhongBan> PhongBans { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>()
                .HasOne(nv => nv.PhongBan)
                .WithMany(pb => pb.NhanViens)
                .HasForeignKey(nv => nv.MaPhongBan);
        }
    }
}
