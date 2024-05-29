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
    public class OrderController : ControllerBase
    {
        private OrderSvc orderSvc;
        public OrderController() 
        {
            orderSvc= new OrderSvc();
        }
        [HttpPost ("Get-All-Order")]
        public IActionResult getAllOrder()
        {
            var res = new SingleRsp();
            res.Data = orderSvc.All;
            return Ok(res);
        }
        [HttpPost("Get-by-ID")]
        public IActionResult GetOrderByID([FromBody] SimpleReq req)
        {

            var res = new SingleRsp();
            res = orderSvc.Read(req.Id);
            return Ok(res);

        }
         

        // done Note : em them Don Hang dung bo ID vao. No tang tu dong nen ko can gan ID ben Swagger
        [HttpPost("Create-Order")]
        public IActionResult CreateOrder([FromBody] OrderReq orderReq)
        {
         
            return Ok(orderSvc.CreateOrder(orderReq));
        }

        // done
        [HttpDelete("Delete{id}")]
        public IActionResult DeleteOrder(int id)
        {
            return Ok(orderSvc.DeleteOrder(id));
        }
        [HttpPut("Update-Order")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderReq orderReq)
        {
            var res = orderSvc.UpdateOrder(id, orderReq);

            return Ok(res);
        }

    }
    
    
}
