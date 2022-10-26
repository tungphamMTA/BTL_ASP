﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop1.Models;

namespace Shop1.Areas.Admin.Controllers
{
    public class ManageOrdersController : Controller
    {
        // GET: Admin/ManageOrder
        public ActionResult Index()
        {
            using (var con = new DBContext())
            {
                var model = con.HOADON.ToList();
                return View(model);
            }
        }
        public ActionResult Search(string key)
        {
            var con = new DBContext();



            //var model = con.HangSanXuat.Where(x => x.TenHang.Contains(key)).ToList();
            //con.HangSanXuat = model;
            ViewBag.key = key;


            return View("~/Areas/Admin/Views/Search/Search.cshtml", con);

        }
    }
}