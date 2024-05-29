using QLBH.Common.BLL;
using QLBH.Common.DAL;
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
    public class OrderDetailSvc: GenericSvc<OrderDetailRep, ChiTietDh>
    {
        private OrderDetailRep orderDetailRep;
        public OrderDetailSvc()
        {
            orderDetailRep = new OrderDetailRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            res.Data = _rep.Read(id);
            return res;
        }
        public SingleRsp CreateOrderDetail(OrderDetailReq orderDetailReq)
        {

            ChiTietDh ct = new ChiTietDh();
            ct.MaDh = orderDetailReq.MaDh;
            ct.MaSp = orderDetailReq.MaSp;
            ct.MaGiamGia = orderDetailReq.MaGiamGia;
            ct.SoLuong = orderDetailReq.SoLuong;
            ct.DonGia = orderDetailReq.DonGia;


            return orderDetailRep.CreateOrderDetail(ct);
        }

        public SingleRsp DeleteOrderDetail(int id)
        {
            var res = new SingleRsp();

            var exist = _rep.Read(id);
            if (exist == null)
            {
                res.SetError($"Không tìm thấy đơn mã  {id} ");
                return res;
            }

            orderDetailRep.DeleteOrderDetail(exist);
            res.SetMessage("Xóa thành công .");
            return res;
        }

        public SingleRsp UpdateOrderDetail(int id, OrderDetailReq orderDetailReq)
        {
            var res = new SingleRsp();
            var orderDetail = orderDetailRep.Read(id);
            orderDetail.MaDh = orderDetailReq.MaDh;
            orderDetail.MaSp = orderDetailReq.MaSp;
            orderDetail.MaGiamGia = orderDetailReq.MaGiamGia;
            orderDetail.SoLuong = orderDetailReq.SoLuong;
            orderDetail.DonGia = orderDetailReq.DonGia;
            res = orderDetailRep.UpdateOrderDetail(orderDetail);
            return res;
        }
    }
}
