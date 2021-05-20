namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatMon")]
    public partial class DatMon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDatMon { get; set; }

        [Required]
        [StringLength(10)]
        public string MaBan { get; set; }

        public int MaMonAn { get; set; }

        public DateTime? ThoiGian { get; set; }

        public int? SoLuong { get; set; }

        public decimal GiaMon { get; set; }

        public int TrangThai { get; set; }

        public int MaHoaDon { get; set; }

        public virtual Ban Ban { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual MonAn MonAn { get; set; }
    }
}
