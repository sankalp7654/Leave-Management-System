using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Controllers
{
    public class PostingPlaceController : Controller
    {
        private LeaveManagementDBEntities db = new LeaveManagementDBEntities();

        // GET: PostingPlace
        public ActionResult Index()
        {
            return View(db.Posting_Place.ToList());
        }

        // GET: PostingPlace/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posting_Place posting_Place = db.Posting_Place.Find(id);
            if (posting_Place == null)
            {
                return HttpNotFound();
            }
            return View(posting_Place);
        }

        // GET: PostingPlace/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostingPlace/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] Posting_Place posting_Place)
        {
            if (ModelState.IsValid)
            {
                db.Posting_Place.Add(posting_Place);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(posting_Place);
        }

        // GET: PostingPlace/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posting_Place posting_Place = db.Posting_Place.Find(id);
            if (posting_Place == null)
            {
                return HttpNotFound();
            }
            return View(posting_Place);
        }

        // POST: PostingPlace/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] Posting_Place posting_Place)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posting_Place).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(posting_Place);
        }

        // GET: PostingPlace/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posting_Place posting_Place = db.Posting_Place.Find(id);
            if (posting_Place == null)
            {
                return HttpNotFound();
            }
            return View(posting_Place);
        }

        // POST: PostingPlace/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Posting_Place posting_Place = db.Posting_Place.Find(id);
            db.Posting_Place.Remove(posting_Place);
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
