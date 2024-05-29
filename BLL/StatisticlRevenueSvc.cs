using QLBH.Common.BLL;
using QLBH.DAL.Models;
using QLBH.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Common.Req;
using QLBH.Common.Rsp;

namespace QLBH.BLL
{
    public class StatisticlRevenueSvc : GenericSvc<StatisticlRevenueRep, DonHang>
    {
        private StatisticlRevenueRep statisticRep;

        public StatisticlRevenueSvc()
        {
            statisticRep = new StatisticlRevenueRep(); //tạo mới đối tượng DLL

        }
        
        public SingleRsp TongDoanhThuTheoNam( int year)
        {
            var res = new SingleRsp();
            var totalRevenue = statisticRep.TongDoanhThuTheoNam(year);
            var result = new
            {
                Year = year,
                TongDoanhThu = totalRevenue
            };
            res.Data= result;
            return res;
        }
        public object TongDoanhThuTheoQuy(int quarter, int year)
        {
            if (quarter < 1 || quarter > 4)
            {
                throw new ArgumentException("Invalid quarter. Quarter should be between 1 and 4.");
            }

            int currentYear = year;
            decimal totalRevenue = statisticRep.TongDoanhThuTheoQuy(currentYear, quarter);

            return new
            {
                Year = currentYear,
                Quarter = quarter,
                TongDoanhThu = totalRevenue
            };
        }
        public SingleRsp TongDoanhThuTheoThangCuaNam(int month, int year )
        {
            var res = new SingleRsp();
            var total = statisticRep.TongDoanhThuTheoThangCuaNam(month, year);
            
            if (month < 1 || month > 12)
            {
                
                throw new ArgumentException("Tháng không hợp lệ");
            }
            var result = new
            {
                Year = year,
                Month = month,
                TongDoanhThu = total
            };
            res.Data = result;
            return res;
        }
        public List<object> CountOrdersByMaKh(string id )
        {
            return statisticRep.CountOrdersByMaKh(id);
        }
        public List<object> CountTotalRevenueByMaKh(string id)
        {
            return statisticRep.CountTotalRevenueByMaKh(id);
        }

    }
}

