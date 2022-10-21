using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop1.Models;

namespace Shop1.Areas.Admin.Controllers
{
    public class ManageBrandsController : Controller
    {
        // GET: Admin/ManageBrands
        public ActionResult Index()
        {
            using (var con = new DBContext())
            {
                var model = con.HangSanXuat.ToList();
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
    }
}