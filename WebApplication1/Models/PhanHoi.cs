namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanHoi")]
    public partial class PhanHoi
    {
        [Key]
        [StringLength(10)]
        public string MaPhanHoi { get; set; }

        [StringLength(100)]
        public string TenKhachHang { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string ChuDe { get; set; }

        [Column(TypeName = "ntext")]
        public string LoiNhan { get; set; }

        public int? MaMonAn { get; set; }

        public DateTime? ThoiGian { get; set; }

        public int TrangThai { get; set; }

        public virtual MonAn MonAn { get; set; }
    }
}
