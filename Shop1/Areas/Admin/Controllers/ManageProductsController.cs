using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop1.Models;
using System.Web.Mvc;
using PagedList;

namespace Shop1.Areas.Admin.Controllers
{
    public class ManageProductsController : Controller
    {
        // GET: Admin/ManageProducts
        //public DBContext con = new DBContext();
        public ActionResult Index(string key = "", int page=1)
        {
            using (var con = new DBContext())
            {
                var objs = con.SanPham.ToList();

                var model = objs.OrderByDescending(x => x.MaSP).ToPagedList(page, 10);
                ViewBag.count = model.Count;
                ViewBag.task = "Index";
                ViewBag.controller = "ManageProducts";
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            using (var con = new DBContext())
            {

                var hangSX = con.HangSanXuat.ToList();
                ViewBag.hangSX = hangSX;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(SanPham model)
        {
            try
            {
                using (var con = new DBContext())
                {
                    con.SanPham.Add(model);
                    con.SaveChanges();
                    //return RedirectToAction("Index");
                    return Json(new { message = "Success!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(new { message = "Faill" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {

            using (var con = new DBContext())
            {
                var obj = con.SanPham.FirstOrDefault(x => x.MaSP ==id);
                var hangSX = con.HangSanXuat.ToList();
                ViewBag.HangSX = hangSX;
                return View(obj);

            }
        }

        [HttpPost]
        public ActionResult Edit(SanPham model)
        {
            try
            {
                using (var con = new DBContext())
                {
                    var obj = con.SanPham.Find(model.MaSP);
                    obj.MaSP = model.MaSP;
                    obj.TenSP = model.TenSP;
                    obj.HangSX = model.HangSX;
                    obj.XuatXu = model.XuatXu;
                    obj.GiaGoc = model.GiaGoc;
                    obj.GiaTien = model.GiaTien;
                    obj.SoLuong = model.SoLuong;
                    con.SaveChanges();
                    return Json(new { message = "Success!" }, JsonRequestBehavior.AllowGet);

                }
                // TODO: Add update logic here
            }
            catch
            {
                return Json(new { message = "Fail!" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                using (var con = new DBContext())
                {
                    var obj = con.SanPham.Find(id);
                    con.SanPham.Remove(obj);
                    var t = con.SaveChanges();
                    return Json(new { message = "Success!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(new { message = "Fail!" }, JsonRequestBehavior.AllowGet);

            }

        }
        public ActionResult Search(string key, int page=1)
        {
            using (DBContext con = new DBContext())
            {

                ViewBag.Key = key;
                var objs = con.SanPham.Where(x => x.TenSP.Contains(key) || x.XuatXu.Contains(key) || x.MoTa.Contains(key)).ToList();

                var model = objs.OrderByDescending(x => x.MaSP).ToPagedList(page, 10);
                ViewBag.count = model.Count;
                ViewBag.task = "Search";
                ViewBag.controller = "ManageProducts";
                return View("Index", model);
            }

        }
    }

   
}