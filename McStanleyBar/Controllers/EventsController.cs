using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using McStanleyBar.Models;
using McStanleyBar.ViewModels;

namespace McStanleyBar.Controllers
{
    public class EventsController : Controller
    {
        //private string eventCacheKey = CacheKeys.Events();

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            var events = db.Events.Include(e => e.Genre).Include(e => e.Venue);
            return View(events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "GenreName");
            ViewBag.VenueId = new SelectList(db.Venues, "Id", "Name");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,StartTime,StartDate,GenreId,VenueId")] Events events)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(events);
                db.SaveChanges();

                db.Events.Add(events);
                db.SaveChanges();
                // clear my cache of the old stuff, 
                HttpRuntime.Cache.Remove("events");
                // re-add to the my cache
                var eventdata = new ApplicationDbContext().Events.Include(i => i.Genre).Include(i => i.Venue).ToList();
                // add to cache
                HttpRuntime.Cache.Add(
                    "events",
                    eventdata,
                    null,
                    DateTime.Now.AddDays(7),
                    new TimeSpan(),
                    System.Web.Caching.CacheItemPriority.High, //High- means that it is one of the last things to be removed from the cache
                   null
              );
                return RedirectToAction("Index");

            }
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "GenreName", events.GenreId);
            ViewBag.VenueId = new SelectList(db.Venues, "Id", "Name", events.VenueId);
            return View(events);
        }
           


    // GET: Events/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Events events = db.Events.Find(id);
        if (events == null)
        {
            return HttpNotFound();
        }
        ViewBag.GenreId = new SelectList(db.Genres, "Id", "GenreName", events.GenreId);
        ViewBag.VenueId = new SelectList(db.Venues, "Id", "Name", events.VenueId);
        return View(events);
    }

    // POST: Events/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Title,StartTime,StartDate,GenreId,VenueId")] Events events)
    {
        if (ModelState.IsValid)
        {
            db.Entry(events).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.GenreId = new SelectList(db.Genres, "Id", "GenreName", events.GenreId);
        ViewBag.VenueId = new SelectList(db.Venues, "Id", "Name", events.VenueId);
        return View(events);
    }

    // GET: Events/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Events events = db.Events.Find(id);
        if (events == null)
        {
            return HttpNotFound();
        }
        return View(events);
    }

    // POST: Events/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Events events = db.Events.Find(id);
        db.Events.Remove(events);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            db.Dispose();
        }
        base.Dispose(disposing);
    }
}
}
