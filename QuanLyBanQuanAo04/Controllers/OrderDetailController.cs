using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL;
using QLBH.DAL.Models;

namespace QuanLyBanQuanAo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private OrderDetailSvc orderDetailSvc;
        public OrderDetailController()
        {
            orderDetailSvc = new OrderDetailSvc();
        }
        [HttpPost("Get-All-OrderDetail")]
        public IActionResult getAllOrderDetail()
        {
            var res = new SingleRsp();
            res.Data = orderDetailSvc.All;
            return Ok(res);
        }

        [HttpPost("Get-by-ID")]
        public IActionResult GetOrderByID([FromBody] SimpleReq req)
        {

            var res = new SingleRsp();
            res = orderDetailSvc.Read(req.Id);
            return Ok(res);

        }
        [HttpPost("Create-OrderDetail")]
        public IActionResult CreateOrderDetail([FromBody] OrderDetailReq orderDetailReq)
        {

            return Ok(orderDetailSvc.CreateOrderDetail(orderDetailReq));
        }

        [HttpDelete("Delete{id}")]
        public IActionResult DeleteOrderDetail(int id)
        {
            return Ok(orderDetailSvc.DeleteOrderDetail(id));
        }

        [HttpPut("Update-OrderDetail")]
        public IActionResult UpdateOrderDetail(int id, [FromBody] OrderDetailReq orderDetailReq)
        {
            var res = orderDetailSvc.UpdateOrderDetail(id, orderDetailReq);

            return Ok(res);
        }
    }
}
