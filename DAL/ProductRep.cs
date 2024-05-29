using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
    public class ProductRep : GenericRep<QLBHContext, SanPham>
    {
        private readonly QLBHContext da;
        public ProductRep()
        {
            da = new QLBHContext();
        }
        public override SanPham Read(string keyword)
        {
            var res = All.FirstOrDefault(s => s.MaSp == keyword);
            return res;
        }

        public SingleRsp CreateProduct(SanPham product)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.SanPhams.Add(product);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetData("201", "Them san pham thanh cong.!");

                    }
                    catch (DbUpdateException dbEx)
                    {
                        tran.Rollback();
                        var innerException = dbEx.InnerException?.Message ?? dbEx.Message;
                        res.SetError($"Database update exception: {innerException}");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();

                        res.SetError($"Exception: {ex}");
                    }
                }
            }
            return res;
        }
        public SingleRsp UpdateProduct(SanPham product)
        {
            var res = new SingleRsp();

            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.SanPhams.Update(product);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Cập nhật sản phẩm thành công!!!!");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Cập nhật sản phẩm thất bại!!!!");
                    }
                }
            }
            return res;
        }
        public SingleRsp DeleteProduct(SanPham product)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.SanPhams.Remove(product);
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


        public List<SanPham> SearchProduct(string keyWord)
        {
            
           
            return All.Where(x => x.TenSp.Contains(keyWord)).ToList();
        }

       
    }
}
