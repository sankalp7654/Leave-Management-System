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
    public class TypeOfInstituteController : Controller
    {
        private LeaveManagementDBEntities db = new LeaveManagementDBEntities();

        // GET: TypeOfInstitute
        public ActionResult Index()
        {
            return View(db.Type_Of_Institute.ToList());
        }

        // GET: TypeOfInstitute/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_Of_Institute type_Of_Institute = db.Type_Of_Institute.Find(id);
            if (type_Of_Institute == null)
            {
                return HttpNotFound();
            }
            return View(type_Of_Institute);
        }

        // GET: TypeOfInstitute/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeOfInstitute/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] Type_Of_Institute type_Of_Institute)
        {
            if (ModelState.IsValid)
            {
                db.Type_Of_Institute.Add(type_Of_Institute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(type_Of_Institute);
        }

        // GET: TypeOfInstitute/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_Of_Institute type_Of_Institute = db.Type_Of_Institute.Find(id);
            if (type_Of_Institute == null)
            {
                return HttpNotFound();
            }
            return View(type_Of_Institute);
        }

        // POST: TypeOfInstitute/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] Type_Of_Institute type_Of_Institute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type_Of_Institute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(type_Of_Institute);
        }

        // GET: TypeOfInstitute/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_Of_Institute type_Of_Institute = db.Type_Of_Institute.Find(id);
            if (type_Of_Institute == null)
            {
                return HttpNotFound();
            }
            return View(type_Of_Institute);
        }

        // POST: TypeOfInstitute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Type_Of_Institute type_Of_Institute = db.Type_Of_Institute.Find(id);
            db.Type_Of_Institute.Remove(type_Of_Institute);
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
