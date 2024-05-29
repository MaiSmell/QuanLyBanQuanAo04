using Microsoft.EntityFrameworkCore;
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
    public class OrderRep: GenericRep<QLBHContext, DonHang>
    {
        //lay ra don hang theo id
        public override DonHang Read(int id)
        {

            var res = All.FirstOrDefault(o => o.MaDh == id);

            return res;
        }
       
       
        //thêm đơn hàng
        //public SingleRsp CreateOrder(DonHang order)
        //{
        //    var res = new SingleRsp();
        //    using (var context = new QLBHContext())
        //    {
        //        using (var tran = context.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                var p = context.DonHangs.Add(order);
        //                context.SaveChanges();
        //                tran.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                tran.Rollback();
        //                res.SetError(ex.StackTrace);
        //            }
        //        }
        //    }
        //    return res;
        //}
        public SingleRsp CreateOrder(DonHang order)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.DonHangs.Add(order);
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

        public SingleRsp DeleteOrder(DonHang order)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.DonHangs.Remove(order);
                        context.SaveChanges();
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
        public SingleRsp UpdateOrder (DonHang order)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.DonHangs.Update(order);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Cập nhật thành công");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Cập nhật thất bại ");
                    }
                }
            }
            return res;
        }
        

    }
}
