using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Common.Req
{
    public class OrderDetailReq
    {
        public int MaDh { get; set; }
        public string MaSp { get; set; }
        public string MaGiamGia { get; set; }
        public double? DonGia { get; set; }
        public int? SoLuong { get; set; }


    }
}
