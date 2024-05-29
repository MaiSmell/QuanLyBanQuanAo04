using Microsoft.EntityFrameworkCore;
using QLBH.Common.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAL
{
    public class StatisticProductRep : GenericRep<QLBHContext, ChiTietDh>
    {
        private readonly QLBHContext da;

        public StatisticProductRep()
        {
            da = new QLBHContext();
        }
        public decimal GetTotalRevenueByColor(string color)
        {
            return da.ChiTietDhs
                .Join(da.SanPhams, c => c.MaSp, s => s.MaSp, (c, s) => new
                {
                    Color = s.MauSac,
                    TotalRevenue = (decimal)(c.SoLuong * c.DonGia)
                })
                .Where(x => x.Color == color)
                .Sum(x => x.TotalRevenue);
        }
    }
}
