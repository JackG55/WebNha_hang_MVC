namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinNguoiQuanLy")]
    public partial class ThongTinNguoiQuanLy
    {
        [Key]
        [StringLength(10)]
        public string TenDangNhap { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(3)]
        public string GioiTinh { get; set; }

        [StringLength(150)]
        public string DiaChi { get; set; }

        public virtual QuanLy QuanLy { get; set; }
    }
}
