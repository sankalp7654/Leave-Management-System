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
    public class BlockHQController : Controller
    {
        private LeaveManagementDBEntities db = new LeaveManagementDBEntities();

        // GET: BlockHQ
        public ActionResult Index()
        {
            return View(db.Block_HQ.ToList());
        }

        // GET: BlockHQ/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Block_HQ block_HQ = db.Block_HQ.Find(id);
            if (block_HQ == null)
            {
                return HttpNotFound();
            }
            return View(block_HQ);
        }

        // GET: BlockHQ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlockHQ/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] Block_HQ block_HQ)
        {
            if (ModelState.IsValid)
            {
                db.Block_HQ.Add(block_HQ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(block_HQ);
        }

        // GET: BlockHQ/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Block_HQ block_HQ = db.Block_HQ.Find(id);
            if (block_HQ == null)
            {
                return HttpNotFound();
            }
            return View(block_HQ);
        }

        // POST: BlockHQ/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] Block_HQ block_HQ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(block_HQ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(block_HQ);
        }

        // GET: BlockHQ/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Block_HQ block_HQ = db.Block_HQ.Find(id);
            if (block_HQ == null)
            {
                return HttpNotFound();
            }
            return View(block_HQ);
        }

        // POST: BlockHQ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Block_HQ block_HQ = db.Block_HQ.Find(id);
            db.Block_HQ.Remove(block_HQ);
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
