﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop1.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult AddItem()
        {
            return View();
        }
    }
}