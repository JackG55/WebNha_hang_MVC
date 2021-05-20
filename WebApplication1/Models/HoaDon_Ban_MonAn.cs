using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class HoaDon_Ban_MonAn
    {
        public int MaHoaDon { get; set; }
        public string TenBan { get; set; }

        public DateTime? GioVao { get; set; }

        public DateTime? GioRa { get; set; }

        public int? TongTien { get; set; }

        public double? KhuyenMai { get; set; }

        public string NguoiLapHoaDon { get; set; }

      
    }
}