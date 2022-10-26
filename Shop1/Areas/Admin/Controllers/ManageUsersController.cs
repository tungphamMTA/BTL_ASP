using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop1.Models;
using PagedList;

namespace Shop1.Areas.Admin.Controllers
{
    public class ManageUsersController : Controller
    {
        // GET: Admin/ManageUsers
        public ActionResult Index(string key = "", int page = 1)
        {
            using (var con = new DBContext())
            {
                var model = con.AspNetUsers.ToList().ToPagedList(page, 10);
                ViewBag.count = model.Count;
                ViewBag.task = "Index";
                ViewBag.controller = "ManageUsers";
                return View(model);
            }
        }
        public ActionResult Search(string key="", int page = 1)
        {
            using (DBContext con = new DBContext())
            {

                ViewBag.Key = key;
                var objs = con.AspNetUsers.Where(x => x.HoTen.Contains(key) || x.SDT.Contains(key) || x.UserName.Contains(key) || x.Email.Contains(key) || x.DiaChi.Contains(key)).ToList();

                var model = objs.OrderByDescending(x => x.HoTen).ToPagedList(page, 10);
                ViewBag.count = model.Count;
                ViewBag.task = "Search";
                ViewBag.controller = "ManageUsers";
                return View("Index", model);
            }

        }
    }
}