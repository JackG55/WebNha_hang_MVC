using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DatMon_HoaDon_MonAn
    {
        public string MaBan { get; set; }
        public int MaDatMon { get; set; }
        public int MaHoaDon { get; set; }

        public int MaMonAn { get; set; }

        [StringLength(200)]
        public string TenMonAn { get; set; }

        [StringLength(200)]
        public string HinhAnh { get; set; }

        public decimal GiaMon { get; set; }

        public decimal? GiaKhuyenMai { get; set; }

        public int TrangThai { get; set; }

        public int? SoLuong { get; set; }

         public DateTime? GioVao { get; set; }

        public DateTime? GioRa { get; set; }


        [StringLength(10)]
        public string NguoiLapHoaDon { get; set; }

        public int? TongTien { get; set; }
    }
}