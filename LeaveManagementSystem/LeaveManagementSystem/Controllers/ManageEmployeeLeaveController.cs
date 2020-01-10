using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Controllers
{
    public class ManageEmployeeLeaveController : Controller
    {
        private LeaveManagementDBEntities db = new LeaveManagementDBEntities();
       
        // GET: ManageEmployeeLeave
        public ActionResult Index()
        {
            ViewBag.Leave_ID = new SelectList(db.Leaves, "id", "name");
            return View();
        }

        // POST: ManageEmployeeLeave
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "emp_code,leave_id,date_from,date_to,financial_year_start,financial_year_end,gender")] Employees_Take_Leaves etl)
        {
            Employees_Take_Leaves employeeTakeLeave = new Employees_Take_Leaves();

            employeeTakeLeave.emp_code = "NHM" + etl.emp_code;
            employeeTakeLeave.leave_id = etl.leave_id;
            employeeTakeLeave.date_from = etl.date_from;
            employeeTakeLeave.date_to = etl.date_to;
            employeeTakeLeave.financial_year_start = etl.financial_year_start;
            employeeTakeLeave.financial_year_end = etl.financial_year_end;
            employeeTakeLeave.absent_days = 0;

            TimeSpan difference = employeeTakeLeave.date_to - employeeTakeLeave.date_from;
            employeeTakeLeave.no_of_days = (int)difference.TotalDays;

            bool flag = false;

            // Maternity Leave Count
            if (employeeTakeLeave.leave_id == 1)
            {
                // Select the particular row
                var getRow = db.Employees_Other_Leave_Counts.Where(s => s.maternity_leave_count_left >= 0).SingleOrDefault(s => s.code == employeeTakeLeave.emp_code);

                // Select the particular column value from the selected Row
                int maternityLeaveCount = getRow.maternity_leave_count_left;

                if (maternityLeaveCount != 0)
                {
                    if (ModelState.IsValid)
                    {
                        db.Employees_Other_Leave_Counts.Where(s => s.code == employeeTakeLeave.emp_code).ToList().ForEach(a => a.maternity_leave_count_left = maternityLeaveCount - 1);
                        db.SaveChanges();
                        flag = true;
                    }

                    // Marking the absent if employee applies for Maternity Leave > 180 days
                    if (employeeTakeLeave.no_of_days > 180)
                    {
                        employeeTakeLeave.absent_days = employeeTakeLeave.no_of_days - 180;
                    }
                }
                else
                {
                    // leave cannot be granted


                }

            }
            // Paternity Leave Count
            else if (employeeTakeLeave.leave_id == 2)
            {
                // Select the particular row
                var getRow = db.Employees_Other_Leave_Counts.Where(s => s.paternity_leave_count_left >= 0).SingleOrDefault(s => s.code == employeeTakeLeave.emp_code);

                // Select the particular column value from the selected Row
                int paternityLeaveCount = getRow.paternity_leave_count_left;

                employeeTakeLeave.absent_days = 0;

                if (paternityLeaveCount != 0)
                {
                    if (ModelState.IsValid)
                    {

                        db.Employees_Other_Leave_Counts.Where(s => s.code == employeeTakeLeave.emp_code).ToList().ForEach(a => a.paternity_leave_count_left = paternityLeaveCount - 1);
                        db.SaveChanges();
                        flag = true;

                    }

                    // Marking the absent if employee applies for Paternity Leave > 15 days
                    if (employeeTakeLeave.no_of_days > 15)
                    {
                        employeeTakeLeave.absent_days = employeeTakeLeave.no_of_days - 15;
                    }
                }
                else
                {
                    // leave cannot be granted

                }

            }
            // Child Adoption Leave Count
            else if (employeeTakeLeave.leave_id == 3)
            {
                // Select the particular row
                var getRow = db.Employees_Other_Leave_Counts.Where(s => s.child_adoption_leave_count_left >= 0).SingleOrDefault(s => s.code == employeeTakeLeave.emp_code);

                // Select the particular column value from the selected Row
                int childAdoptionLeaveCount = getRow.child_adoption_leave_count_left;

                employeeTakeLeave.absent_days = 0;

                if (childAdoptionLeaveCount != 0)
                {
                    if (ModelState.IsValid)
                    {
                        db.Employees_Other_Leave_Counts.Where(s => s.code == employeeTakeLeave.emp_code).ToList().ForEach(a => a.child_adoption_leave_count_left = childAdoptionLeaveCount - 1);
                        db.SaveChanges();
                        flag = true;

                    }

                    // Marking the absent if employee applies for Child Adoption Leave > 40 days
                    if (employeeTakeLeave.no_of_days > 40)
                    {
                        employeeTakeLeave.absent_days = employeeTakeLeave.no_of_days - 40;
                    }
                }
                else
                {
                    // leave cannot be granted

                }

            }
            // Medical Leave Count
            else if (employeeTakeLeave.leave_id == 4)
            {
                var getMedicalLeaveOfEmployee = db.Employees_Take_Leaves.Where(s => s.emp_code == employeeTakeLeave.emp_code).Where(s => s.leave_id == employeeTakeLeave.leave_id).Where(s => s.financial_year_start == employeeTakeLeave.financial_year_start).Where(s => s.financial_year_end == employeeTakeLeave.financial_year_end).ToList();
                var leavesTakenForDays = 0;

                for(int i = 0; i < getMedicalLeaveOfEmployee.Count(); i++)
                {
                    leavesTakenForDays += getMedicalLeaveOfEmployee[i].no_of_days;
                }

                if((getMedicalLeaveOfEmployee == null) || (leavesTakenForDays < 15))
                {
                    if(employeeTakeLeave.no_of_days > 15)
                    {
                        flag = false;
                        // employeeTakeLeave.absent_days = employeeTakeLeave.no_of_days - 15;
                    }
                    else
                    {
                        flag = true;
                    }

                }
                else
                {
                    // medical leave cannot be granted
                    if(flag == false)
                        ViewBag.result = "Maximum Number of Medical Leaves reached!";
                    ViewBag.result = "Maximum Number of Medical Leaves reached!";
                    return View();
                }

            }
            
            // Finally persisting the row values inside Employee Take Leave database
            if (flag)
            {
                if (ModelState.IsValid)
                {
                    db.Employees_Take_Leaves.Add(employeeTakeLeave);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(etl);
        }

        [HttpPost]
        public JsonResult GetEmployeeDetails(string code)
        {
            LeaveManagementDBEntities db = new LeaveManagementDBEntities();
            if (code != null)
            {
                var getRow = db.Employees.SingleOrDefault(s => s.code == code);
                if(getRow == null)
                {
                    return null;
                }
                
                var post = db.Posts.FirstOrDefault(s => s.id == getRow.post_id).name;
                var gender = getRow.gender;
                var postingPlace = db.Posting_Place.FirstOrDefault(s => s.id == getRow.posting_place_id).name;
                var typeOfInstitute = db.Type_Of_Institute.FirstOrDefault(s => s.id == getRow.type_of_institute_id).name;
                var blockHq = db.Block_HQ.FirstOrDefault(s => s.id == getRow.block_id).name;
                
                return Json(new { success = true, post = post, posting_place = postingPlace, gender = gender, type_of_institute = typeOfInstitute, block_hq = blockHq });
                
            }
            return Json(new { success = false });
        }
    }
}