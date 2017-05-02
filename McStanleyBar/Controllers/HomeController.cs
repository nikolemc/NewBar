﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using McStanleyBar.Models;
using McStanleyBar.ViewModels;

namespace McStanleyBar.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            var events = db.Events.Include(e => e.Genre).Include(e => e.Venue).ToList();
            var eventsToDisplay = new HomePageViewModel(){Event = events};
            return View(eventsToDisplay);
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
    }
}