namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ban")]
    public partial class Ban
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ban()
        {
            DatMons = new HashSet<DatMon>();
        }

        [Key]
        [StringLength(10)]
        public string MaBan { get; set; }

        [StringLength(50)]
        public string TenBan { get; set; }

        public int TrangThai { get; set; }

        [StringLength(20)]
        public string Vitri { get; set; }

        public virtual Ban_HoaDon Ban_HoaDon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatMon> DatMons { get; set; }
    }
}
