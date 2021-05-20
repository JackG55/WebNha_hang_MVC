namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Ban> Bans { get; set; }
        public virtual DbSet<Ban_HoaDon> Ban_HoaDon { get; set; }
        public virtual DbSet<DatMon> DatMons { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<LoaiMon> LoaiMons { get; set; }
        public virtual DbSet<MonAn> MonAns { get; set; }
        public virtual DbSet<PhanHoi> PhanHois { get; set; }
        public virtual DbSet<QuanLy> QuanLies { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThongTinNguoiQuanLy> ThongTinNguoiQuanLies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ban>()
                .Property(e => e.MaBan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Ban>()
                .Property(e => e.TenBan)
                .IsUnicode(false);

            modelBuilder.Entity<Ban>()
                .HasOptional(e => e.Ban_HoaDon)
                .WithRequired(e => e.Ban);

            modelBuilder.Entity<Ban>()
                .HasMany(e => e.DatMons)
                .WithRequired(e => e.Ban)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ban_HoaDon>()
                .Property(e => e.MaBan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DatMon>()
                .Property(e => e.MaBan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DatMon>()
                .Property(e => e.GiaMon)
                .HasPrecision(10, 0);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.NguoiLapHoaDon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.DatMons)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiMon>()
                .Property(e => e.TieuDe)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiMon>()
                .HasMany(e => e.MonAns)
                .WithRequired(e => e.LoaiMon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonAn>()
                .Property(e => e.GiaMon)
                .HasPrecision(10, 0);

            modelBuilder.Entity<MonAn>()
                .Property(e => e.GiaKhuyenMai)
                .HasPrecision(10, 0);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.DatMons)
                .WithRequired(e => e.MonAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.PhanHois)
                .WithRequired(e => e.MonAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhanHoi>()
                .Property(e => e.MaPhanHoi)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhanHoi>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<QuanLy>()
                .Property(e => e.TenDangNhap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<QuanLy>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<QuanLy>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.QuanLy)
                .HasForeignKey(e => e.NguoiLapHoaDon);

            modelBuilder.Entity<ThongTinNguoiQuanLy>()
                .Property(e => e.TenDangNhap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinNguoiQuanLy>()
                .Property(e => e.GioiTinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinNguoiQuanLy>()
                .HasOptional(e => e.QuanLy)
                .WithRequired(e => e.ThongTinNguoiQuanLy);
        }
    }
}
