using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DatMon_Image
    {
        public int MaMonAn  { set; get; }

        public string TenMonAn { set; get; }
        public string MaBan { set; get; }
        public int MaHoaDon { set; get; }
        public int SoLuong { set; get; }
        public Decimal GiaMon { set; get; }
        public int Gia { set; get; }
        public DateTime ThoiGian { set; get; }
        public int TrangThai { set; get; }
        public int MaDatMon { set; get; }

        public string HinhAnh { set; get; }
    }
}