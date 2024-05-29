using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietDhs = new HashSet<ChiTietDh>();
            SanPhamSizes = new HashSet<SanPhamSize>();
        }

        public string MaSp { get; set; }
        public string MaLh { get; set; }
        public string TenSp { get; set; }
        public double DonGia { get; set; }
        public int SoLuongTonKho { get; set; }
        public DateTime? NgayNhapHang { get; set; }
        public bool? GiamGia { get; set; }
        public byte[] Anh { get; set; }
        public string MauSac { get; set; }

        public virtual LoaiHang MaLhNavigation { get; set; }
        public virtual ICollection<ChiTietDh> ChiTietDhs { get; set; }
        public virtual ICollection<SanPhamSize> SanPhamSizes { get; set; }
    }
}
