using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Shop1.Models;

namespace Shop1.Areas.Admin.Controllers
{
    public class ManageOrdersController : Controller
    {
        // GET: Admin/ManageOrder
        public ActionResult Index(string key="", int page = 1)
        {
            using (var con = new DBContext())
            {
                var model = con.HOADON.ToList().ToPagedList(page, 10);
                ViewBag.count = model.Count;
                ViewBag.task = "Index";
                ViewBag.controller = "ManageOrders";
                return View(model);
            }
        }
        public ActionResult Search(string key, int page = 1)
        {
            using (DBContext con = new DBContext())
            {

                ViewBag.Key = key;
                var objs = con.HOADON.Where(x => x.MaDH.Contains(key) || x.HoTen.Contains(key) || x.MaKH.Contains(key) || x.TinhTrangDH.Contains(key)).ToList();

                var model = objs.OrderByDescending(x => x.MaSP).ToPagedList(page, 10);
                ViewBag.count = model.Count;
                ViewBag.task = "Search";
                ViewBag.controller = "ManageOrders";
                return View("Index", model);
            }

        }
    }
}