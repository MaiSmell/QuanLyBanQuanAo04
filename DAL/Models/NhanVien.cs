using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public string MaNv { get; set; }
        public string HoNv { get; set; }
        public string TenNv { get; set; }
        public string DiaChiNv { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Email { get; set; }
        public string ChucVu { get; set; }
        public double? Luong { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
