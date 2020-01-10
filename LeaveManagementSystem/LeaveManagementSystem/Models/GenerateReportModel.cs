using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaveManagementSystem.Models
{
    public class GenerateReportModel
    {
        public string code { get; set; }
        public string name { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
        public int no_of_days { get; set; }
        public int financial_year_start { get; set; }
        public int financial_year_end { get; set; }
        public int absent_days { get; set; }
        public string leave_name { get; set; }
        public int leave_id { get; set; }
        

    }
}