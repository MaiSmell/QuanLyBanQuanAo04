using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class GiaoHang
    {
        public GiaoHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public string MaShipper { get; set; }
        public string Sdt { get; set; }
        public string DonViGiao { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
