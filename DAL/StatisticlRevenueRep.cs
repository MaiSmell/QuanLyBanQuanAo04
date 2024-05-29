using Microsoft.EntityFrameworkCore;
using QLBH.Common.DAL;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAL
{

    public class StatisticlRevenueRep : GenericRep<QLBHContext, DonHang>
    {
        private readonly QLBHContext da;

        public StatisticlRevenueRep()
        {
            da = new QLBHContext();
        }

        public decimal TongDoanhThuTheoNam(int year)
        {
            var total = da.DonHangs
                 .Where(s => s.NgayDatHang.Value.Year == year)
                  .Join(da.ChiTietDhs, d => d.MaDh, c => c.MaDh, (d, c) => (decimal)(c.SoLuong * c.DonGia))
                 .Sum();
            return total;

        }
        public decimal TongDoanhThuTheoQuy (int year, int quarter)
        {
            DateTime startDate, endDate;

            switch (quarter)
            {
                case 1:
                    startDate = new DateTime(year, 1, 1);
                    endDate = new DateTime(year, 3, 31);
                    break;
                case 2:
                    startDate = new DateTime(year, 4, 1);
                    endDate = new DateTime(year, 6, 30);
                    break;
                case 3:
                    startDate = new DateTime(year, 7, 1);
                    endDate = new DateTime(year, 9, 30);
                    break;
                case 4:
                    startDate = new DateTime(year, 10, 1);
                    endDate = new DateTime(year, 12, 31);
                    break;
                default:
                    throw new ArgumentException("Quý không hợp lệ!!!!");
            }

            var total = da.DonHangs
                .Where(s => s.NgayDatHang >= startDate && s.NgayDatHang <= endDate)
                .Join(da.ChiTietDhs, d => d.MaDh, c => c.MaDh, (d, c) => (decimal)(c.SoLuong * c.DonGia))
                .Sum();

            return total;
        }
        public decimal TongDoanhThuTheoThangCuaNam(int month, int year)
        {
            int currentYear = year;
            //int currentYear = DateTime.Now.Year;
            DateTime startDate = new DateTime(currentYear, month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            var total = da.DonHangs
                .Where(s => s.NgayDatHang >= startDate && s.NgayDatHang <= endDate)
                .Join(da.ChiTietDhs, d => d.MaDh, c => c.MaDh, (d, c) => (decimal)(c.SoLuong * c.DonGia))
                .Sum();
            return total;
        }
        public List<object> CountOrdersByMaKh(string id)
        {
            var ds = da.DonHangs
                .Where(s => s.MaKh == id)
                .GroupBy(s => s.MaKh)
                .Select(s => new { s.Key, Soluongdonhang = s.Count() })
                .ToList<object>();
            return ds;
        }
        public List<object> CountTotalRevenueByMaKh(string id)
        {
            var ds = da.DonHangs
                .Where(s => s.MaKh == id)
                .Join(da.ChiTietDhs, d => d.MaDh, o => o.MaDh, (d, o) => new { d.MaDh, Tongtien = o.SoLuong * o.DonGia })
                .GroupBy(s => s.MaDh)
                .Select(s => new { s.Key, Soluong = s.Sum(s => s.Tongtien) })
                .ToList<object>();
            return ds;
        }
    }
}
