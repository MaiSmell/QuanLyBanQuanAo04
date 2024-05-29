using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL;

namespace QuanLyBanQuanAo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategorySvc categorySvc;
        public CategoryController()
        {
            categorySvc = new CategorySvc();
        }
        //lấy ds khách hàng
        [HttpPost("Get-All-Category")]
        public IActionResult GetAllCategory()
        {
            var res = new SingleRsp();
            res.Data = categorySvc.All;
            return Ok(res);
        }
        //lấy thông tin loai hàng theo id 
        [HttpPost("Get-by-ID")]
        public IActionResult GetCategoryByID([FromBody] SimpleReq req)
        {

           
            return Ok(categorySvc.Read(req.Keyword));
        }

        [HttpPost("Create-Category")]
        public IActionResult CreateCategory([FromBody] CategoryReq categoryReq)
        {
            //var res = new SingleRsp
            return Ok(categorySvc.CreateCategory(categoryReq));
        }

        [HttpPut("Update-Category")]
        public IActionResult UpdateCategory(string keyWord, [FromBody] CategoryReq categoryReq)
        {
            if (!string.Equals(keyWord, categoryReq.MaLh))
            {
                return BadRequest("Không tồn tại sản phẩm ");
            }
            var res = new SingleRsp();
            res = categorySvc.UpdateCategory(categoryReq);
            return Ok(res);

        }
        [HttpDelete("Delete-Category")]
        public IActionResult DeleteCategory([FromBody] SimpleReq req)
        {

            return Ok(categorySvc.DeleteCategory(req.Keyword));
        }

        [HttpPost("Search-Category")]
        public IActionResult SearchCategory([FromBody] SearchCategoryReq searchCategoryReq)
        {
            var res = new SingleRsp();
            res.Data = categorySvc.SearchCategory(searchCategoryReq);
            return Ok(res);
        }

    }
}
