using QLBH.Common.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.BLL
{
    public class EmployeeSvc : GenericSvc<EmployeeRep, NhanVien>
    {
        private EmployeeRep employeeRep;

        public EmployeeSvc()
        {
            employeeRep = new EmployeeRep(); //tạo mới đối tượng DLL

        }
        public override SingleRsp Read(string keyword)
        {
            var res = new SingleRsp();

            res.SetData("200", employeeRep.Read(keyword));
            return res;
        }

        public SingleRsp CreateEmployee(EmployeeReq employeeReq)
        {
            var res = new SingleRsp();
            NhanVien nhanVien = new NhanVien();
            nhanVien.MaNv = employeeReq.MaNv;
            nhanVien.HoNv = employeeReq.HoNv;
            nhanVien.TenNv = employeeReq.TenNv;
            nhanVien.DiaChiNv = employeeReq.DiaChiNv;
            nhanVien.NgaySinh = employeeReq.NgaySinh;
            nhanVien.Email = employeeReq.Email;
            nhanVien.ChucVu = employeeReq.ChucVu;
            nhanVien.Luong = employeeReq.Luong;


            employeeRep.CreateEmployee(nhanVien);
            res.SetData("201", "Create successful.!");
            return res;
           
        }

        public SingleRsp DeleteEmployee(string keyword)
        {
            var res = new SingleRsp();
            NhanVien nv = employeeRep.Read(keyword);
            if (nv != null)
            {
                employeeRep.DeleteEmployee(nv);
                res.SetMessage("Xóa thành công .");
                return res;
            }
            else
            {
                res.SetError($"Không tìm thấy nhân viên mã  {keyword} ");
                return res;
            }
        }

        public SingleRsp UpdateEmployee(EmployeeReq employeeReq)
        {
            var res = new SingleRsp();

            var exist = _rep.Read(employeeReq.MaNv);

            exist.MaNv = employeeReq.MaNv;
            exist.HoNv = employeeReq.HoNv;
            exist.TenNv = employeeReq.TenNv;
            exist.DiaChiNv = employeeReq.DiaChiNv;
            exist.NgaySinh = employeeReq.NgaySinh;
            exist.Email = employeeReq.Email;
            exist.ChucVu = employeeReq.ChucVu;
            exist.Luong = employeeReq.Luong;


            res = employeeRep.UpdateEmployee(exist);

            return res;
        }
        
    }
}
