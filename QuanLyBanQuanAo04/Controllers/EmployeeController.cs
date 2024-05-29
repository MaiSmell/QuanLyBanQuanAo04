using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;

namespace QuanLyBanQuanAo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        

        private EmployeeSvc employeeSvc;
        public EmployeeController()
        {
            employeeSvc = new EmployeeSvc();

        }

        [HttpPost("Get-All-Employee")]
        public IActionResult getAllOrder()
        {
            var res = new SingleRsp();
            res.Data = employeeSvc.All;
            return Ok(res);
        }

        [HttpPost("Get-by-id")]
        public IActionResult GetNhanVienByID([FromBody] SimpleReq req)
        {

            return Ok(employeeSvc.Read(req.Keyword));
        }


        [HttpPost("create-Employee")]
        public IActionResult CreateEmployee([FromBody] EmployeeReq employeeReq)
        {

            return Ok(employeeSvc.CreateEmployee(employeeReq));
        }


        [HttpDelete("Delete-Employee")]
        public IActionResult DeleteEmployee([FromBody] SimpleReq req)
        {

            return Ok(employeeSvc.DeleteEmployee(req.Keyword));
        }

        [HttpPut("Update-Employee")]
        public IActionResult UpdateEmployee(string keyWord, [FromBody] EmployeeReq employeeReq)
        {
            if (!string.Equals(keyWord, employeeReq.MaNv))
            {
                return BadRequest("Không tồn tại nhân viên ");
            }
            var res = new SingleRsp();
            res = employeeSvc.UpdateEmployee(employeeReq);
            return Ok(res);

        }
    }
}
