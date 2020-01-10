using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaveManagementSystem.Models;
using Microsoft.Reporting.WebForms;

namespace LeaveManagementSystem.Controllers
{
    public class GenerateReportController : Controller
    {
        private LeaveManagementDBEntities db = new LeaveManagementDBEntities();
        private GenerateReportViewModel gvm = new GenerateReportViewModel();

        // GET: GenerateReport
        public ActionResult Index()
        {
            ViewBag.leave_id = new SelectList(db.Leaves, "id", "name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(GenerateReportViewModel grvm)
        {
            GenerateReportModel grm = new GenerateReportModel();

            var getRows = db.Employees_Take_Leaves.Where(s => s.financial_year_start == grvm.financial_year_start).Where(s => s.financial_year_end == grvm.financial_year_end).Where(s => s.leave_id == grvm.leave_id);
            var leaveName = db.Leaves.FirstOrDefault(s => s.id == grvm.leave_id).name;

            grm.leave_name = leaveName;
            grm.leave_id = grvm.leave_id;
            grm.financial_year_end = grvm.financial_year_end;
            grm.financial_year_start = grvm.financial_year_start;

            return RedirectToAction("GetReports", "GenerateReport", grm);
        }

        [HttpGet]
        public ActionResult GetReports(GenerateReportModel grm)
        {
            return View(grm);
        }

        // Method to Generate the report
        public ActionResult Report(string id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Report"), "FinancialYearLeaveReport.rdlc");
            if(System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            List<Employees_Take_Leaves> cm = new List<Employees_Take_Leaves>();
            using (LeaveManagementDBEntities db = new LeaveManagementDBEntities())
            {
                cm = db.Employees_Take_Leaves.ToList();
            }
            ReportDataSource rd = new ReportDataSource("MyDataSet", cm);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =
                "<DeviceInfo>" +
                "   <OutputFormat>" + id + "</OutputFormat>" +
                "   <PageWidth>8.5in</PageWidth>" +
                "   <PageHeight>11in</PageHeight>" +
                "   <MarginTop>0.5in</MarginTop>" +
                "   <MarginLeft>1in</MarginLeft>" +
                "   <MarginRight>1in</MarginRight>" +
                "   <MarginBottom>0.5in</MarginBottom>" +
                "</DeviceInfo>";




            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            return File(renderedBytes, mimeType);
        }
    }
}