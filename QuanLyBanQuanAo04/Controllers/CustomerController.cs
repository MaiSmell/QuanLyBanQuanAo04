using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuanLyBanQuanAo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerSvc customerSvc;
        public CustomerController()
        {
            customerSvc = new CustomerSvc();
        }
        //lấy ds khách hàng
        [HttpPost("Get-All-Customer")]
        public IActionResult getAllCustomer()
        {
            var res = new SingleRsp();
            res.Data = customerSvc.All;
            return Ok(res);
        }
        //lấy thông tin khách hàng theo id 
        [HttpPost("Get-by-ID")]
        public IActionResult GetCustomerByID([FromBody] SimpleReq req)
        {

            // chỉ cần gọi th customerSvc
            return Ok(customerSvc.Read(req.Keyword));
        }

        [HttpPost("Create-Customer")]
        public IActionResult CreateCustomer([FromBody] CustomerReq customerReq)
        {
            //var res = new SingleRsp
            return Ok(customerSvc.CreateCustomer(customerReq));
        }
        [HttpPut("Update-Customer")]
        public IActionResult UpdateCustomer(string keyWord, [FromBody] CustomerReq customerReq)
        {
            if (!string.Equals(keyWord, customerReq.MaKh))
            {
                return BadRequest("Không tồn tại sản phẩm ");
            }
            var res = new SingleRsp();
            res = customerSvc.UpdateCustomer(customerReq);
            return Ok(res);

        }
        [HttpDelete("Delete-Product")]
        public IActionResult DeleteCustomer([FromBody] SimpleReq req)
        {

            return Ok(customerSvc.DeleteCustomer(req.Keyword));
        }



    }
}
