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
    public class CategoryRep : GenericRep<QLBHContext, LoaiHang>
    {
        public CategoryRep()
        {

        }
        public override LoaiHang Read(string id)
        {
            var res = All.FirstOrDefault(s => s.MaLh == id);
            return res;
        }
        public SingleRsp CreateCategory(LoaiHang loaiHang)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.LoaiHangs.Add(loaiHang);
                        context.SaveChanges();
                        tran.Commit();

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


        public SingleRsp UpdateCategory(LoaiHang loaiHang)
        {
            var res = new SingleRsp();

            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.LoaiHangs.Update(loaiHang);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Cập nhật loại hàng thành công!!!");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Cập nhật loại hàng thất bại!!!");
                    }
                }
            }
            return res;
        }

        public SingleRsp DeleteCategory(LoaiHang loaiHang)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.LoaiHangs.Remove(loaiHang);
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
        public List<LoaiHang> SearchCategory(string keyWord)
        {


            return All.Where(x => x.TenLh.Contains(keyWord)).ToList();
        }
    }
}
