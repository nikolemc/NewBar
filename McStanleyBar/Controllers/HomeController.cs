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

            var eventsFromCache = HttpRuntime.Cache["events"] as IEnumerable<Events>;
            if (eventsFromCache == null)
            {
                var eventdata = db.Events.Include(e => e.Genre).Include(e => e.Venue).OrderBy(t => t.StartDate).ToList();
                // add to cache
                HttpRuntime.Cache.Add(
                    "events",
                    eventdata,
                    null,
                    DateTime.Now.AddDays(7),
                    new TimeSpan(),
                    System.Web.Caching.CacheItemPriority.High, //High- means that it is one of the last things to be removed from the cache
                    null);
                eventsFromCache = eventdata as IEnumerable<Events>;

            }
            var vm = new HomePageViewModel
            {
                Event = eventsFromCache,
                ShoppingCart = Session["cart"] as Order ?? new Order()
            };
            return View(vm);
        }




        [HttpPost]
        public ActionResult AddToCart(int eventId)
        {
            //        add that event to the order in session
            //      get the order in the session, create if it doesnt exists
            var cart = Session["cart"] as Order;
            if (cart == null)
            {
                cart = new Order();
            }
            var eventToAdd = db.Events.FirstOrDefault(f => f.Id == eventId);
             //create the ticket
            var ticket = new Ticket
            {
                EventId = eventToAdd.Id,
                PurchasePrice = eventToAdd.Price,
                Event = eventToAdd
            };
            cart.Tickets.Add(ticket);

            //save the new cart to seession
            Session["cart"] = cart;
            //retrutn the partial with the updated stuff
            return PartialView("_shoppingCart", cart);
        }



    }
}