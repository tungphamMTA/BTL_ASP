using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop1.Models;
using PagedList;

namespace Shop1.Areas.Admin.Controllers
{
    public class ManageBrandsController : Controller
    {
        // GET: Admin/ManageBrands
        public ActionResult Index(string key = "", int page = 1)
        {
            using (var con = new DBContext())
            {
                var model = con.HangSanXuat.ToList().ToPagedList(page, 10);
                ViewBag.count = model.Count;
                ViewBag.task = "Index";
                ViewBag.controller = "ManageBrands";
                return View(model);
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(HangSanXuat model)
        {
            try
            {
                // TODO: Add insert logic here
                using (var con = new DBContext())
                {
                    con.HangSanXuat.Add(model);
                    con.SaveChanges();
                    return Json(new { message = "Success!" }, JsonRequestBehavior.AllowGet);
                }

            }
            catch
            {
                return Json(new { message = "Fail!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Edit(string id)
        {
            using (var con = new DBContext())
            {
                var obj = con.HangSanXuat.Find(id);
                //con.SaveChanges();
                return View(obj);
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(HangSanXuat model)
        {
            try
            {
                using (var con = new DBContext())
                {
                    var obj = con.HangSanXuat.Find(model.HangSX);
                    obj.HangSX = model.HangSX;
                    obj.TenHang = model.TenHang;
                    obj.TruSoChinh = model.TruSoChinh;
                    obj.QuocGia = model.QuocGia;
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
        public ActionResult Delete(string id)
        {
            try
            {
                using (var con = new DBContext())
                {
                    var obj = con.HangSanXuat.Find(id);
                    con.HangSanXuat.Remove(obj);
                    con.SaveChanges();
                    return Json(new { message = "Success!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { message = "Fail!" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Search(string key, int page = 1)
        {
            using (DBContext con = new DBContext())
            {

                ViewBag.Key = key;
                var objs = con.HangSanXuat.Where(x => x.TenHang.Contains(key) || x.TruSoChinh.Contains(key) || x.QuocGia.Contains(key)).ToList();

                var model = objs.OrderByDescending(x => x.HangSX).ToPagedList(page, 10);
                ViewBag.count = model.Count;
                ViewBag.task = "Search";
                ViewBag.controller = "ManageProducts";
                return View("Index", model);
            }

        }
    }
}