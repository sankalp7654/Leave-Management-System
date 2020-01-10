using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaveManagementSystem.Models
{
    public class GenerateReportViewModel
    {
        public int financial_year_start { get; set; }
        public int financial_year_end { get; set; }
        public int leave_id { get; set; }

        public virtual Leave Leave { get; set; }
    }
}

