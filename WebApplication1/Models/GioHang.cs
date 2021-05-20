using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class GioHang
    {
        public MonAn monAn { get; set; }
       // public int MaMonAn { get; set; }
        //public string TenMonAn { get; set; }
        public string MaBan { get; set; }

        public int MaHoaDon { get; set; }

        public int SoLuong { get; set; }

        public decimal GiaMon { get; set; }

        public int Gia { get; set; }
        public string thoigiandathang { get; set; }

        public int TrangThai { get; set; }

        public int MaDatMon { get; set; }
       // public string HinhAnh { get; set; }


    }
}