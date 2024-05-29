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
    public class EmployeeRep : GenericRep<QLBHContext, NhanVien>
    {
        public override NhanVien Read(string id)
        {
            var res = All.FirstOrDefault(s => s.MaNv == id);
            return res;
        }

        public SingleRsp CreateEmployee(NhanVien nhanVien)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.NhanViens.Add(nhanVien);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetData("201", "Them nhan vien thanh cong.!");

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
        public SingleRsp DeleteEmployee(NhanVien nhanVien)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.NhanViens.Remove(nhanVien);
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

       

        public SingleRsp UpdateEmployee(NhanVien nhanVien)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.NhanViens.Update(nhanVien);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Cập nhật nhân viên  thành công!!!");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Cập nhật nhân viên thất bại!!!");
                    }
                }
            }
            return res;
        }
    }
}
