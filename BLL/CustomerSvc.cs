using Microsoft.EntityFrameworkCore.Storage;
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
    public class CustomerSvc : GenericSvc<CustomerRep,KhachHang> //kế thừa genericSvc trong common, truyền vào DAL lấy bảng KH
    {
        private CustomerRep customerRep; // giao tiep DAL
        public CustomerSvc() 
        { 
            customerRep= new CustomerRep(); //tạo mới đối tượng DLL

        }

        // nếu get bằng id là int thì gọi tạo như thằng hàm dạng 1,
        // còn nếu muốn get id là dạng string thì theo hàm dạng 2

        //
        // var res = new SingleRsp();
        // res.SetData(" << status> ", << dữ liệu trả về gọi từ hàm customRsp >> );
        // ex : customRsp.Read, customRsp.Update,....
        // res.Data bên trong có 2 tham số : 200 là status, còn tham số 2 là dữ liệu trả về .
        // 200 : OK -> get thành công.
        // 201 : CREATED -> đung để tạo thành công.
        // 204 : NOT FOUND -> id khách hàng hoạc gì đó không tồn tại.
        // 404 : ERRORR -> bị lỗi cú pháop
        // 500 trở lên : lỗi máy chủ 


        // dạng 1
        //public override SingleRsp Read(int id)
        //{
        //    var res = new SingleRsp();
        //    res.Data =_rep.Read(id);
        //    return res;
        //}

        // dạng 2
        public override SingleRsp Read(string keyword)
        {
            var res = new SingleRsp();

            res.SetData("200", customerRep.Read(keyword));
            return res;
        }

        //public SingleRsp CreateCustomer(CustomerReq customerReq)
        //{
        //    var res = new SingleRsp();
        //    KhachHang khachHang = new KhachHang();
        //    khachHang.MaKh = customerReq.MaKh;
        //    khachHang.HoKh = customerReq.HoKh;
        //    khachHang.TenKh = customerReq.TenKh;
        //    khachHang.Sdt = customerReq.Sdt;
        //    khachHang.DiaChi = customerReq.DiaChi;
        //    khachHang.TinhThanh = customerReq.TinhThanh;

        //    res = customerReq.CreateCustomer(khachHang);
        //    return res;
        //}


        public SingleRsp UpdateCustomer(CustomerReq customerReq)
        {
            var res = new SingleRsp();

            var exist = _rep.Read(customerReq.MaKh);

            exist.MaKh = customerReq.MaKh;
            exist.HoKh = customerReq.HoKh;
            exist.TenKh = customerReq.TenKh;
            exist.DiaChi = customerReq.DiaChi;
            exist.Sdt = customerReq.Sdt;
            exist.TinhThanh = customerReq.TinhThanh;


            res = customerRep.UpdateCustomer(exist);
            return res;
        }
        // them don hang
        public SingleRsp CreateCustomer(CustomerReq customerReq)
        {
            var res = new SingleRsp();
            KhachHang khachHang = new KhachHang();
            khachHang.MaKh = customerReq.MaKh;
            khachHang.HoKh = customerReq.HoKh;
            khachHang.TenKh = customerReq.TenKh;
            khachHang.TinhThanh = customerReq.TinhThanh;
            khachHang.DiaChi = customerReq.DiaChi;
            khachHang.Sdt = customerReq.Sdt;

            customerRep.CreatCustomer(khachHang);
            res.SetData("201", "Create successful.!");
            return res;
        }

        public SingleRsp DeleteCustomer(string keyword)
        {
            var res = new SingleRsp();
            KhachHang c = customerRep.Read(keyword);
            if (c != null)
            {
                customerRep.DeleteCustomer(c);
                res.SetMessage("Xóa thành công .");
                return res;
            }
            else
            {
                res.SetError($"Không tìm thấy khách hàng mã  {keyword} ");
                return res;
            }
        }
    }
}
