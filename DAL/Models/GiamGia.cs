using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class GiamGia
    {
        public GiamGia()
        {
            ChiTietDhs = new HashSet<ChiTietDh>();
        }

        public string MaGiamGia { get; set; }
        public string TenMaGiam { get; set; }

        public virtual ICollection<ChiTietDh> ChiTietDhs { get; set; }
    }
}
