using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Common.Req
{
    public class EmployeeReq
    {
        public string MaNv { get; set; }
        public string HoNv { get; set; }
        public string TenNv { get; set; }
        public string DiaChiNv { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Email { get; set; }
        public string ChucVu { get; set; }
        public double? Luong { get; set; }
    }
}
