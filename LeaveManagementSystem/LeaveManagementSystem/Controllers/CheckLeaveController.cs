using LeaveManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveManagementSystem.Controllers
{
    public class CheckLeaveController : Controller
    {
        private LeaveManagementDBEntities db = new LeaveManagementDBEntities();

        // GET: CheckLeave
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CheckLeaveViewModel checkLeaveViewModel)
        {
            Employees_Other_Leave_Counts eolc = new Employees_Other_Leave_Counts();
            CheckLeaveModel checkLeaveModel = new CheckLeaveModel();
            List<Employees_Take_Leaves> etlList = new List<Employees_Take_Leaves>();

            checkLeaveViewModel.code = "NHM" + checkLeaveViewModel.code;
            var getRow = db.Employees_Other_Leave_Counts.FirstOrDefault(s => s.code == checkLeaveViewModel.code);
            if (getRow == null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Invalid Employee Code. Go back and Try Again!');</script>");

            }

            var getTotalAbsentRows = db.Employees_Take_Leaves.Where(s => s.emp_code == checkLeaveViewModel.code).ToList();
            var getLeaveDetails = db.Employees_Take_Leaves.Where(s => s.emp_code == checkLeaveViewModel.code).ToList();
            var getLeaveTypes = db.Leaves.Select(row => row).ToList();
            var getNameRow = db.Employees.FirstOrDefault(s => s.code == checkLeaveViewModel.code);

            checkLeaveModel.code = getRow.code;
            checkLeaveModel.name = getNameRow.name;
            checkLeaveModel.maternity_leave_count_left = getRow.maternity_leave_count_left;
            checkLeaveModel.paternity_leave_count_left = getRow.paternity_leave_count_left;
            checkLeaveModel.child_adoption_leave_count_left = getRow.child_adoption_leave_count_left;
            checkLeaveModel.absentDays = 0;



            for (int i = 0; i < getTotalAbsentRows.Count(); i++)
            {
                checkLeaveModel.absentDays += getTotalAbsentRows[i].absent_days;
            }

            /*
            for (int i = 0; i < getLeaveTypes.Count(); i++)
            {
                for (int j = 0; j < getLeaveDetails.Count(); j++)
                {
                    if (getLeaveDetails[j].leave_id == getLeaveTypes[i].id)
                    {
                        Employees_Take_Leaves etl = new Employees_Take_Leaves();
                        etl.emp_code = getLeaveDetails[j].emp_code;
                        etl.leave_id = getLeaveDetails[j].leave_id;
                        etl.date_from = getLeaveDetails[j].date_from;
                        etl.date_to = getLeaveDetails[j].date_to;
                        etl.financial_year_start = getLeaveDetails[j].financial_year_start;
                        etl.financial_year_end = getLeaveDetails[j].financial_year_end;
                        etl.absent_days = getLeaveDetails[j].absent_days;
                        etlList.Add(etl);
                        //checkLeaveModel.persistantObjects.Add(etl);
                    }
                }
            }
            */

            return RedirectToAction("GetLeaveCounts", "CheckLeave", checkLeaveModel);
        }

        private string alert(string v)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult GetLeaveCounts(CheckLeaveModel checkLeaveModel)
        {
            return View(checkLeaveModel);
        }
    }
}