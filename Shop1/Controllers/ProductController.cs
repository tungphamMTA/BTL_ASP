using Shop1.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace Shop1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        DBContext con = new DBContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Product()
        {
            return PartialView(con.SanPham.ToList());
        }
        public PartialViewResult BestSellerProduct()
        {

            return PartialView(con.SanPham.Take(6).OrderByDescending(x => x.SoLuongBan).ToList());

        }
        public PartialViewResult NewProduct()
        {
            return PartialView(con.SanPham.Take(10).Where(x => x.isnew == true).ToList());

        }
        public PartialViewResult SaleProduct()
        {

            return PartialView(con.SanPham.Take(10).Where(x => x.GiaSale < x.GiaTien).ToList());

        }

        public PartialViewResult Related(string hang)
        {
            return PartialView(con.SanPham.Where(x => x.HangSX == hang).ToList());
        }
    }
}