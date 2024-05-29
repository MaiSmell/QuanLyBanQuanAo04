using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class SanPhamSize
    {
        public string Size { get; set; }
        public string MaSp { get; set; }
        public int? SoLuong { get; set; }

        public virtual SanPham MaSpNavigation { get; set; }
        public virtual Size SizeNavigation { get; set; }
    }
}
