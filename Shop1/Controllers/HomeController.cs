using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop1.Models;
using Shop1.Controllers;
using PagedList;

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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Shop(int page = 1, int pageSize = 9)
        {
            List<SanPham> sanPham = con.SanPham.ToList();
            var segmentList = new List<listofSegments>();
            listofSegments segmentItem;
            var arr = new string[] { "9", "12", "24", "36" };
            for (int idx =0; idx< arr.Length; idx++)
            {
                segmentItem = new listofSegments();
                segmentItem.Text = arr[idx];
                segmentItem.Value = arr[idx];
                segmentList.Add(segmentItem);
            }
            ViewBag.segmentList = segmentList;
            var model = sanPham.OrderByDescending(x => x.GiaGoc).ToPagedList(page, pageSize);
            return View(model);
        }

        [HttpPost]
        public ActionResult ActionPostData(string Segmentation)
        {
            return RedirectToAction("Shop", new { pageSize = Convert.ToInt32(Segmentation) });
        }
    }
}