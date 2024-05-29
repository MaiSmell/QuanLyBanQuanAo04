using QLBH.Common.BLL;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.BLL
{
    public class StatisticProductSvc : GenericSvc<StatisticProductRep, ChiTietDh>
    {
        private StatisticProductRep statisticProductRep;

        public StatisticProductSvc()
        {
            statisticProductRep = new StatisticProductRep(); //tạo mới đối tượng DLL

        }
        public decimal CalculateTotalByColor(string color)
        {
            return statisticProductRep.GetTotalRevenueByColor(color);
        }
    }
}
