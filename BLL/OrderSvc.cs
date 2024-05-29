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
    public class OrderSvc : GenericSvc<OrderRep, DonHang>
    {
        private OrderRep orderRep;
        //public override SingleRsp Read(int id)
        //{
        //    var res = new SingleRsp();
        //    var m = _rep.Read(id);
        //    res.Data = m;
        //    return res;
        //}

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
           
            res.Data = _rep.Read(id);
            return res;
        }
        public OrderSvc()
        {
            orderRep = new OrderRep();
        }


        // them don hang
        public SingleRsp CreateOrder(OrderReq orderReq)
        {

            DonHang donHang = new DonHang();

            donHang.MaKh = orderReq.MaKh;
            donHang.MaNv = orderReq.MaNv;
            donHang.MaShipper = orderReq.MaShipper;
            donHang.PhiVc = orderReq.PhiVc;
            donHang.NgayGiaoHang = orderReq.NgayGiaoHang;
            donHang.NgayDatHang = orderReq.NgayDatHang;
            donHang.DcgiaoHang = orderReq.DCGiaoHang;
            donHang.TinhThanhDh = orderReq.TinhThanh;

            return orderRep.CreateOrder(donHang);
        }

        public SingleRsp DeleteOrder(int id)
        {
            var res = new SingleRsp();

            var exist = _rep.Read(id);
            if (exist == null)
            {
                res.SetError($"Không tìm thấy sản phẩm mã  {id} ");
                return res;
            }

            orderRep.DeleteOrder(exist);
            res.SetMessage("Xóa thành công .");
            return res;
        }

        public SingleRsp UpdateOrder(int id, OrderReq orderReq)
        {
            var res = new SingleRsp();
            var order = orderRep.Read(id);
            
            order.MaKh = order.MaKh;
            order.MaShipper = order.MaShipper;
            order.ChiTietDhs = order.ChiTietDhs;
            order.PhiVc = order.PhiVc;
            order.ChiTietDhs = order.ChiTietDhs;
            order.NgayDatHang = order.NgayDatHang;
            order.NgayGiaoHang = order.NgayGiaoHang;
            res = orderRep.UpdateOrder(order);
            return res;
        }
        //public SingleRsp SearchProduct(SearchProductcReq searchProductcReq)
        //{
        //    var res = new SingleRsp();
        //    //lấy dssp theo từ khóa
        //    var product = productRep.SearchProduct(searchProductcReq.KeyWord);
        //    //xử lý phân trang 
        //    int pCount, totalPage, offSet;
        //    offSet = searchProductcReq.Size * (searchProductcReq.Page - 1);
        //    pCount = product.Count;

        //    totalPage = (pCount % searchProductcReq.Size) == 0 ? pCount / searchProductcReq.Size : 1
        //        + (pCount / searchProductcReq.Size);
        //    var p = new
        //    {
        //        Data = product.Skip(offSet).Take(searchProductcReq.Size).ToList(),
        //        page = searchProductcReq.Page,
        //        Size = searchProductcReq.Size
        //    };
        //    res.Data = p;
        //    return res;
        //}

    }
}
