namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonAn")]
    public partial class MonAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonAn()
        {
            DatMons = new HashSet<DatMon>();
            PhanHois = new HashSet<PhanHoi>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaMonAn { get; set; }

        [StringLength(200)]
        public string TenMonAn { get; set; }

        [StringLength(250)]
        public string MoTa { get; set; }

        [StringLength(200)]
        public string HinhAnh { get; set; }

        public decimal GiaMon { get; set; }

        public decimal? GiaKhuyenMai { get; set; }

        public int MaLoaiMon { get; set; }

        public DateTime? NgayTao { get; set; }

        public int? ThuTuXuatHien { get; set; }

        [StringLength(200)]
        public string TuKhoaTimKiem { get; set; }

        public int TrangThai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TopHot { get; set; }

        [StringLength(20)]
        public string DonViTinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatMon> DatMons { get; set; }

        public virtual LoaiMon LoaiMon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanHoi> PhanHois { get; set; }
    }
}
