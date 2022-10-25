using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop1.Models;

namespace Shop1.Areas.Admin.Controllers
{
    public class ManageUsersController : Controller
    {
        // GET: Admin/ManageUsers
        public ActionResult Index()
        {
            using (var con = new DBContext())
            {
                var model = con.AspNetUsers.ToList();
                return View(model);
            }
        }
    }
}