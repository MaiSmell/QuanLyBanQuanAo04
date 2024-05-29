using QLBH.Common.BLL;
using QLBH.Common.Rsp;
using QLBH.DAL.Models;
using QLBH.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Common.Req;
using System.Security.Cryptography;
using System.Collections;

namespace QLBH.BLL
{
    public class ProductSvc : GenericSvc<ProductRep, SanPham>
    {
        private ProductRep productRep;

        public ProductSvc()
        {
            productRep = new ProductRep(); //tạo mới đối tượng DLL

        }
        public override SingleRsp Read(string keyword)
        {
            var res = new SingleRsp();

            res.SetData("200", productRep.Read(keyword));
            return res;
        }

        
        public SingleRsp UpdateProduct(string keyWord, ProductReq productReq)
        {
            var res = new SingleRsp();

            var exist = _rep.Read(productReq.MaSp);
            
           
            exist.MaLh = productReq.MaLh;
            exist.TenSp = productReq.TenSp;
            exist.DonGia = productReq.DonGia;
            exist.SoLuongTonKho = productReq.SoLuongTonKho;
            exist.NgayNhapHang = productReq.NgayNhapHang;
            exist.MauSac = productReq.MauSac;
            exist.GiamGia = productReq.GiamGia;

            res = productRep.UpdateProduct(exist);

            return res;
        }
        public SingleRsp CreateProduct(ProductReq productReq)
        {
          
            SanPham sanPham = new SanPham();
            sanPham.MaSp = productReq.MaSp;
            sanPham.MaLh = productReq.MaLh;
            sanPham.TenSp= productReq.TenSp;
            sanPham.DonGia= productReq.DonGia;
            sanPham.SoLuongTonKho = productReq.SoLuongTonKho;
            sanPham.NgayNhapHang= productReq.NgayNhapHang;
            sanPham.MauSac = productReq.MauSac;
            sanPham.GiamGia = productReq.GiamGia;

            return productRep.CreateProduct(sanPham);
        }
        public SingleRsp DeleteProduct(string keyword)
        {
            var res = new SingleRsp();
            SanPham sp = productRep.Read(keyword);
            if (sp != null)
            {
                productRep.DeleteProduct(sp);
                res.SetMessage("Xóa thành công .");
                return res;
            }
            else
            {
                res.SetError($"Không tìm thấy sản phẩm mã  {keyword} ");
                return res;
            }
        }
        public SingleRsp SearchProduct(SearchProductcReq searchProductcReq)
        {
            var res = new SingleRsp();
            //lấy dssp theo từ khóa
            var product = productRep.SearchProduct(searchProductcReq.KeyWord);
            //xử lý phân trang 
            int pCount, totalPage, offSet;
            offSet = searchProductcReq.Size *( searchProductcReq.Page -1);
            pCount = product.Count;

            totalPage = (pCount % searchProductcReq.Size) == 0? pCount / searchProductcReq.Size :1 
                + (pCount / searchProductcReq.Size);
            var p = new
            {
                Data = product.Skip(offSet).Take(searchProductcReq.Size).ToList(),
                page = searchProductcReq.Page,
                Size = searchProductcReq.Size
            };
            res.Data = p;
            return res;
        }
       

    }
}
