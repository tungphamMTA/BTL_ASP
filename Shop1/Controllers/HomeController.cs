using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop1.Models;
using Shop1.Controllers;
using PagedList;
using System.Data.SqlClient;

namespace Shop1.Controllers
{
    public class HomeController : Controller
    {
        public class listofSegments
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }
        DBContext con = new DBContext();
        public ActionResult Index(int page = 1, int pageSize = 9)
        {
            List<SanPham> sanPham = con.SanPham.ToList();
            var model = sanPham.OrderByDescending(x => x.GiaGoc).ToPagedList(page, pageSize);
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [ChildActionOnly]
        public PartialViewResult DanhMucHSXPartial()
        {
            var hang_sx = con.HangSanXuat.ToList();
            return PartialView(hang_sx);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Shop(int page = 1, int pageSize = 9)
        {
            List<SanPham> sanPham = con.SanPham.ToList();
            var model = sanPham.OrderByDescending(x => x.GiaGoc).ToPagedList(page, pageSize);
            return View(model);
        }
        public PartialViewResult SanPhamTheoDanhMuc(string id, int page = 1, int pageSize = 6)
        {

            HangSanXuat dm_HSX = con.HangSanXuat.SingleOrDefault(x => x.TenHang == id);
            if (dm_HSX == null)
            {
                Console.WriteLine("khong co hang san xuat nao");
            }
            List<SanPham> sanphams = con.SanPham.Where(x => x.HangSX == dm_HSX.HangSX).ToList();
            ViewBag.hangsx = id;
            var model = sanphams.OrderByDescending(x => x.GiaGoc).ToPagedList(page, pageSize);
            return PartialView(model);
        }
        public PartialViewResult BoLocSanPham(string id, string gia, int page = 1, int pageSize = 6)
        {
            string khoangGia = gia;
            string[] arr = khoangGia.Split(new string[] { " -- " }, StringSplitOptions.None);
            string hsx = id;
            string query = "";
            if (hsx == "All")
            {
                query = "SELECT * FROM  SANPHAM WHERE GIATIEN > @min AND GIATIEN < @max";
            }
            else
            {
                query = "SELECT * FROM  SANPHAM, HANGSANXUAT WHERE GIATIEN > @min AND GIATIEN < @max AND SANPHAM.HANGSX=HANGSANXUAT.HANGSX AND TENHANG = @ID";
            }
            int min_price, max_price;
            min_price = int.Parse(arr[0]);
            max_price = int.Parse(arr[1]);
            List<SanPham> sanphams = new List<SanPham>();
            SqlParameter[] idParam ={
                new SqlParameter {ParameterName = "min", Value = min_price },
                new SqlParameter{ParameterName = "max", Value = max_price },
            new SqlParameter{ParameterName="ID", Value=hsx} };

            sanphams = con.SanPham.SqlQuery(query, idParam).ToList();
            ViewBag.hangsx = hsx;
            ViewBag.gia = gia;
            var model = sanphams.OrderByDescending(x => x.GiaGoc).ToPagedList(page, pageSize);
            return PartialView("BoLocSanPham",model);
        }
        public PartialViewResult SanPhamTheoDanhMucVaGia(string id, string gia, int page = 1, int pageSize=6)
        {
            string khoangGia = gia;
            string[] arr = khoangGia.Split(new string[] { " -- " }, StringSplitOptions.None);
            string hsx = id;
            string query = "";
            if (hsx == "All")
            {
                query = "SELECT * FROM  SANPHAM WHERE GIATIEN > @min AND GIATIEN < @max";
            }
            else
            {
                query = "SELECT * FROM  SANPHAM, HANGSANXUAT WHERE GIATIEN > @min AND GIATIEN < @max AND SANPHAM.HANGSX=HANGSANXUAT.HANGSX AND TENHANG = @ID";
            }
            int min_price, max_price;
            min_price = int.Parse(arr[0]);
            max_price = int.Parse(arr[1]);
            List<SanPham> sanphams = new List<SanPham>();
            SqlParameter[] idParam ={
                new SqlParameter {ParameterName = "min", Value = min_price },
                new SqlParameter{ParameterName = "max", Value = max_price },
            new SqlParameter{ParameterName="ID", Value=hsx} };

            sanphams = con.SanPham.SqlQuery(query, idParam).ToList();
            ViewBag.hangsx = hsx;
            ViewBag.gia = gia;
            var model = sanphams.OrderByDescending(x => x.GiaGoc).ToPagedList(page, pageSize);
            return PartialView("DSSanPham", model);
        }

        //public ViewResult BoLocGia()
        //{
        //    string khoangGia = Request.QueryString["price"];
        //    string [] arr = khoangGia.Split(new string[] { " -- " }, StringSplitOptions.None);
        //    string hsx = ViewBag.hangsx;
        //    int min_price, max_price;
        //    min_price = int.Parse(arr[0]);
        //    max_price = int.Parse(arr[1]);
        //    List<SanPham> sanphams = new List<SanPham>();
        //    SqlParameter[] idParam ={
        //        new SqlParameter {ParameterName = "min", Value = min_price },
        //        new SqlParameter{ParameterName = "max", Value = max_price }};

        //    sanphams = con.SanPham.SqlQuery("SELECT * FROM  SANPHAM WHERE GIATIEN > @min AND GIATIEN < @max",
        //       idParam).ToList();
        //    var model = sanphams.OrderByDescending(x => x.GiaGoc).ToPagedList(1, 6);
        //    return View("Shop", model);

        //}


        //[HttpPost]
        //public ActionResult ActionPostData(string Segmentation)
        //{
        //    return RedirectToAction("Shop", new { pageSize = Convert.ToInt32(Segmentation) });
        //}
    }
}