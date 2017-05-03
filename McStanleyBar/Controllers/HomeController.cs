using System;
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

        //private string eventCacheKey = "event";

        // GET: Events
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.IsAdministrator = HttpContext.User.IsInRole("administrator");
                ViewBag.IsGeneralUser = HttpContext.User.IsInRole("generalUser");
            }

            //var events = db.Events.Include(e => e.Genre).Include(e => e.Venue).ToList();
            //var eventsToDisplay = new HomePageViewModel(){Event = events};
            //return View(eventsToDisplay);

            var eventsFromCache = HttpRuntime.Cache["events"] as IEnumerable<Events>; ;
            if (eventsFromCache == null)
            {
                var events = db.Events.Include(e => e.Genre).Include(e => e.Venue).OrderBy(t => t.StartDate).ToList();
                // add the menu to cache
                HttpRuntime.Cache.Add(
                    "events",
                    events,
                    null,
                    DateTime.Now.AddDays(7),
                    new TimeSpan(),
                    System.Web.Caching.CacheItemPriority.High, //High- means that it is one of the last things to be removed from the cache
                    null);
                eventsFromCache = HttpRuntime.Cache["events"] as IEnumerable<Events>;
            }

            var vm = new HomePageViewModel
            {
                Event = eventsFromCache,
                ShoppingCart = Session["cart"] as Order ?? new Order()
            };
            return View(vm);


        }
        [HttpPost]
        public ActionResult ShoppingCart(int id)
        {
            var cart = Session["cart"] as Order;
            if (cart == null)
            {
                // create a new cart
                cart = new Order()
                {
                    Fulfilled = false,
                    TimeCreated = DateTime.Now
                };
            }
            // too get the item
            var events = db.Events.Include(e => e.Genre).Include(e => e.Venue).FirstOrDefault(f => f.Id==id);
            // add item select to shopping cart
            cart.Items.Add(events);
            Session["cart"] = cart;
            return PartialView("_shoppingCart", cart);
        }

        [HttpDelete]
        public ActionResult RemoveFromCart(string id)
        {

            var cart = Session["cart"] as Order;
            cart.Items = cart.Items.Where(w => w.TrackerId != Guid.Parse(id)).ToList();
            return PartialView("_checkoutDisplayCart", cart);
        }


        public ActionResult Checkout()
        {
            // Shopping Cart (order) as the model
            var vm = Session["cart"] as Order;
            return View(vm);
        }


    }
}