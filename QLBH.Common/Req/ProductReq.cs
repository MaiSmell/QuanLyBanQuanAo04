using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Common.Req
{
    public class ProductReq 
    {
        public string MaSp { get; set; }
        public string MaLh { get; set; }
        public string TenSp { get; set; }
        public double DonGia { get; set; }
        public int SoLuongTonKho { get; set; }
        public DateTime? NgayNhapHang { get; set; }
        public bool? GiamGia { get; set; }
        public string MauSac { get; set; }
    }
}
