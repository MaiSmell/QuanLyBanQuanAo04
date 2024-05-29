using QLBH.Common.DAL;
using QLBH.Common.Rsp;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAL
{
    public class CustomerRep : GenericRep<QLBHContext, KhachHang> //genericRep trong DAL truyen vao QLBHContext sd bang KhachHang 
    {
        public CustomerRep() 
        { 

        }
        //doc tat ca, lay 1 kh theo id
        public override KhachHang Read(string id)
        {
            var res = All.FirstOrDefault(s => s.MaKh == id);
            return res;
        }

        public SingleRsp CreatCustomer(KhachHang khachHang)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    { 
                        context.KhachHangs.Add(khachHang);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetData("201", "Them khach hang thanh cong.!");

                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();

                        res.SetError(ex.Message); 
                    }
                }
            }
            return res;
        }

        public SingleRsp UpdateCustomer(KhachHang khachHang)
        {
            var res = new SingleRsp();

            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.KhachHangs.Update(khachHang);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Cập nhật khách hàng thành công!!!");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Cập nhật khách hàng thất bại!!!");
                    }
                }
            }
            return res;
        }

        public SingleRsp DeleteCustomer (KhachHang khachHang)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.KhachHangs.Remove(khachHang);
                        int result = context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
    }
}
