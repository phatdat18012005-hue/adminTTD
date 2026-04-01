using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Existing (Vietnamese) entities
    public DbSet<NguoiDung> NguoiDung { get; set; }
    public DbSet<BaiViet> BaiViet { get; set; }
    public DbSet<ThuTucHanhChinh> ThuTucHanhChinh { get; set; }
    public DbSet<HoSoDichVu> HoSoDichVu { get; set; }
    public DbSet<DanhMuc> DanhMuc { get; set; }
    public DbSet<BinhLuan> BinhLuan { get; set; }
    public DbSet<Media> Media { get; set; }
    public DbSet<LienHe> LienHe { get; set; }
    public DbSet<AuditLog> AuditLog { get; set; }

    // Optional English aliases so frontend or other code expecting English names still works.
    // These are not new entity types; they map to the existing classes above.
    public DbSet<DanhMuc> Categories => Set<DanhMuc>();
    public DbSet<BaiViet> Articles => Set<BaiViet>();
    public DbSet<BinhLuan> Comments => Set<BinhLuan>();
    public DbSet<ThuTucHanhChinh> ServiceProcedures => Set<ThuTucHanhChinh>();
    public DbSet<HoSoDichVu> ServiceApplications => Set<HoSoDichVu>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<NguoiDung> Leaders => Set<NguoiDung>(); // if Leader is same as NguoiDung; otherwise create Leader class
}
