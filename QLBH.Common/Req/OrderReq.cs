using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Common.Req
{
    public class OrderReq
    {
        
        public string MaKh { get; set; }
        public string MaNv { get; set; }
        public string MaShipper { get; set; }
        public int PhiVc { get; set; }
        public DateTime? NgayDatHang { get; set; }
        public DateTime? NgayGiaoHang { get; set; }
        public string DCGiaoHang { get; set; }
        public string TinhThanh { get; set; }
    }
}
