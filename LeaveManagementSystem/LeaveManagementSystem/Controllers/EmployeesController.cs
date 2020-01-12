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
    public class EmployeesController : Controller
    {
        private LeaveManagementDBEntities db = new LeaveManagementDBEntities();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.post_id = new SelectList(db.Posts, "id", "name");
            ViewBag.type_of_institute_id = new SelectList(db.Type_Of_Institute, "id", "name");
            ViewBag.posting_place_id = new SelectList(db.Posting_Place, "id", "name");
            ViewBag.block_id = new SelectList(db.Block_HQ, "id", "name");

            // for distinct block names
            //ViewBag.block_name = new SelectList(db.Block_HQ.Select(m => m.name).Distinct(), "name", "name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "code,name,post_id,block_id,type_of_institute_id,posting_place_id,gender")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.code = "NHM" + employee.code;
                db.Employees.Add(employee);
                db.SaveChanges();

                Employees_Other_Leave_Counts elc = new Employees_Other_Leave_Counts();
                elc.code = employee.code;
                // granted to employee in a lifetime basis
                elc.maternity_leave_count_left = 2;
                elc.paternity_leave_count_left = 2;
                elc.child_adoption_leave_count_left = 2;

                db.Employees_Other_Leave_Counts.Add(elc);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            ViewBag.post_id = new SelectList(db.Posts, "id", "name");
            ViewBag.type_of_institute_id = new SelectList(db.Type_Of_Institute, "id", "name");
            ViewBag.posting_place_id = new SelectList(db.Posting_Place, "id", "name");
            ViewBag.block_id = new SelectList(db.Block_HQ, "id", "name");

            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "code,name,post_id,block_id,type_of_institute_id,posting_place_id,gender")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employees_Other_Leave_Counts eolc = db.Employees_Other_Leave_Counts.Find(id);
            if(eolc != null)
            {
                db.Employees_Other_Leave_Counts.Remove(eolc);
                db.SaveChanges();
            }

            var etl = db.Employees_Take_Leaves.Where(s => s.emp_code == id).ToList();
            for(int i = 0; i < etl.Count(); i++)
            {
                Employees_Take_Leaves obj = db.Employees_Take_Leaves.Find(etl[i].id);
                db.Employees_Take_Leaves.Remove(obj);
                db.SaveChanges();
            }
            
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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

        [HttpPost]
        public JsonResult GetInstitutesList(string blockName)
        {
            LeaveManagementDBEntities db = new LeaveManagementDBEntities();
            if (blockName != null)
            {
                var getBlocks = db.Employees.Where(s => s.name == blockName).ToList();

                

            }



            return Json(new { success = false });
        }

    }
}
