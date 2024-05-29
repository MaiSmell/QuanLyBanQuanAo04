using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public string MaKh { get; set; }
        public string HoKh { get; set; }
        public string TenKh { get; set; }
        public string DiaChi { get; set; }
        public string TinhThanh { get; set; }
        public string Sdt { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
