﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McStanleyBar.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            return View();
        }
    }
}