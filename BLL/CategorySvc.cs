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
    public class CategorySvc : GenericSvc<CategoryRep , LoaiHang>
    {
        private CategoryRep categoryRep;
        public CategorySvc()
        {
            categoryRep = new CategoryRep(); //tạo mới đối tượng DLL

        }

        public override SingleRsp Read(string keyword)
        {
            var res = new SingleRsp();

            res.SetData("200", categoryRep.Read(keyword));
            return res;
        }

        public SingleRsp CreateCategory (CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            LoaiHang loaiHang = new LoaiHang();
            loaiHang.MaLh = categoryReq.MaLh;
            loaiHang.TenLh = categoryReq.TenLh;
            loaiHang.GhiChu = categoryReq.GhiChu;

            categoryRep.CreateCategory(loaiHang);
            res.SetData("201", "Create successful.!");
            return res;
        }

        public SingleRsp UpdateCategory(CategoryReq categoryReq)
        {
            var res = new SingleRsp();

            var exist = _rep.Read(categoryReq.MaLh);

            exist.MaLh = categoryReq.MaLh;
            exist.TenLh = categoryReq.TenLh;
            exist.GhiChu = categoryReq.GhiChu;
           


            res = categoryRep.UpdateCategory(exist);
            return res;
        }
        public SingleRsp DeleteCategory(string keyword)
        {
            var res = new SingleRsp();
            LoaiHang c = categoryRep.Read(keyword);
            
            if (c != null)
            {

                categoryRep.DeleteCategory(c);
                res.SetMessage("Xóa thành công ");
                return res;
            }
            else
            {
                res.SetError($"Không tìm thấy loại hàng mã  {keyword} ");
                return res;
            }
        }
        public SingleRsp SearchCategory(SearchCategoryReq searchCategoryReq)
        {
            var res = new SingleRsp();
            //lấy dssp theo từ khóa
            var category = categoryRep.SearchCategory(searchCategoryReq.KeyWord);
            //xử lý phân trang 
            int pCount, totalPage, offSet;
            offSet = searchCategoryReq.Size * (searchCategoryReq.Page - 1);
            pCount = category.Count;

            totalPage = (pCount % searchCategoryReq.Size) == 0 ? pCount / searchCategoryReq.Size : 1
                + (pCount / searchCategoryReq.Size);
            var p = new
            {
                Data = category.Skip(offSet).Take(searchCategoryReq.Size).ToList(),
                page = searchCategoryReq.Page,
                Size = searchCategoryReq.Size
            };
            res.Data = p;
            return res;
        }

    }
}
