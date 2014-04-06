using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarMarket.Models;
using Microsoft.AspNet.Identity;

namespace CarMarket.Controllers
{
    public class OfferController : Controller
    {
        private CarMarketDbContext db = new CarMarketDbContext();

        // GET: /Offer/
        public ActionResult Index()
        {
            var offers = db.Offers.Include(o => o.Author);
            return View(offers.ToList());
        }

        [Authorize]
        public ActionResult MyOffers()
        {
            string currentUserId = User.Identity.GetUserId();
            var offers = db.Offers.Include(o => o.Author).Where(o => o.AuthorId == currentUserId);
            return View("Index", offers.ToList());
        }

        // GET: /Offer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // GET: /Offer/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Offer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Exclude = "Id, DatePublished, AuthorId, Author")] Offer offer)
        {
            offer.DatePublished = DateTime.Now;
            offer.AuthorId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                db.Offers.Add(offer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(offer);
        }

        // GET: /Offer/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer.AuthorId != User.Identity.GetUserId())
            {
                return RedirectToAction("Index", "Offer");
            }
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // POST: /Offer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Exclude="DatePublished, AuthorId, Author")] Offer offer)
        {
            Offer oldOffer = db.Offers.Find(offer.Id);
            offer.DatePublished = oldOffer.DatePublished;
            offer.AuthorId = oldOffer.AuthorId;

            if (offer.AuthorId != User.Identity.GetUserId())
            {
                return RedirectToAction("Index", "Offer");
            }

            if (ModelState.IsValid)
            {
                db.Entry(offer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(offer);
        }

        // GET: /Offer/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer.AuthorId != User.Identity.GetUserId())
            {
                return RedirectToAction("Index", "Offer");
            }
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // POST: /Offer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Offer offer = db.Offers.Find(id);
            if (offer.AuthorId != User.Identity.GetUserId())
            {
                return RedirectToAction("Index", "Offer");
            }
            db.Offers.Remove(offer);
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
