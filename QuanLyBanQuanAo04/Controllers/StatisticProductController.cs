using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;

namespace QuanLyBanQuanAo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticProductController : ControllerBase
    {
        private StatisticProductSvc statisticSvc;


        public StatisticProductController()
        {
            statisticSvc = new StatisticProductSvc();

        }
        [HttpPost("Cal-Total-By-Color")]
        public IActionResult CalTotalByColor(string color)
        {
            if (string.IsNullOrEmpty(color))
            {
                return BadRequest("Nhập màu không hợp lệ!!!");
            }

            var total = statisticSvc.CalculateTotalByColor(color);

            if (total == 0)
            {
                return NotFound($"Không tìm thấy {color} ");
            }

            return Ok(new { Color = color, Total = total });
        }

    }
}
