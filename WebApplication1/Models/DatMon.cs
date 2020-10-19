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
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaBan { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaMonAn { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime ThoiGian { get; set; }

        public int? SoLuong { get; set; }

        public decimal? GiaMon { get; set; }

        public int TrangThai { get; set; }

        [StringLength(10)]
        public string MaHoaDon { get; set; }

        public virtual Ban Ban { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual MonAn MonAn { get; set; }
    }
}
