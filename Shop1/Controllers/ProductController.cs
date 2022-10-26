using Shop1.Models;
using Shop1.Models.DetailModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace Shoes_Shop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        
        public ActionResult Index()
        {
            using (DBContext con = new DBContext())
            {
                return View();
            }
        }
        public PartialViewResult Product()
        {
            using (DBContext con = new DBContext())
            {
                var model = con.SanPham.ToList();
                return PartialView("ProductCard", model);
            }
        }
        public ActionResult DSSanpham()
        {
            using (var con = new DBContext())
            {
                var model = con.SanPham.ToList();
                return PartialView("ProductCard", model);
            }
        }

        public PartialViewResult BestSellerProduct()
        {
            using (DBContext con = new DBContext())
            {
                var model = con.SanPham.OrderByDescending(x => x.SoLuongBan).Take(6).ToList();
                return PartialView("ProductCard", model);
            }

        }
        public PartialViewResult NewProduct()
        {
            using (DBContext con = new DBContext())
            {
                var model = con.SanPham.Where(x => x.isnew == true).Take(6).ToList();
                return PartialView("ProductCard", model);
            }
        }
        public PartialViewResult SaleProduct()
        {
            using (DBContext con = new DBContext())
            {
                var model = con.SanPham.Where(x => x.GiaSale < x.GiaTien && x.isnew == false).Take(3).ToList();
                return PartialView("ProductCard", model);
            }
        }

        public PartialViewResult Related(string hang)
        {
            using (DBContext con = new DBContext())
            {
                var model = con.SanPham.Where(x => x.HangSX == hang).Take(3).ToList();
                return PartialView( model);
            }
        }

        //them code doan nay nha
        public ActionResult SingleProduct(string id)
        {

            dynamic model = new ExpandoObject();
            model.sanpham = new ThongTinSanPham().SPViewDetail(id);
            ViewBag.category = new ThongTinSanPham().HViewDetail(model.sanpham.HangSX);
            model.ctsp = new ThongTinSanPham().listCTSP(id);
            model.size = new ThongTinSanPham().listSize(id);
            using (DBContext con = new DBContext())
            {
                model.listSP = con.SanPham.ToList();
            }
            return View(model);

        }
    }
}