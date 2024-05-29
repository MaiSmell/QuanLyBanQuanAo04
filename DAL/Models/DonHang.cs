using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class DonHang
    {
        public DonHang()
        {
            ChiTietDhs = new HashSet<ChiTietDh>();
        }

        public int MaDh { get; set; }
        public string MaKh { get; set; }
        public string MaNv { get; set; }
        public string MaShipper { get; set; }
        public DateTime? NgayDatHang { get; set; }
        public double? PhiVc { get; set; }
        public DateTime? NgayGiaoHang { get; set; }
        public string DcgiaoHang { get; set; }
        public string TinhThanhDh { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; }
        public virtual NhanVien MaNvNavigation { get; set; }
        public virtual GiaoHang MaShipperNavigation { get; set; }
        public virtual ICollection<ChiTietDh> ChiTietDhs { get; set; }
    }
}
