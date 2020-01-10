using System;
using System.Collections.Generic;
using System.Web;

namespace LeaveManagementSystem.Models
{
    public class CheckLeaveModel
    {
        public string code { get; set; }
        public string name { get; set; }
        public int maternity_leave_count_left { get; set; }
        public int paternity_leave_count_left { get; set; }
        public int child_adoption_leave_count_left { get; set; }
        public int absentDays { get; set; }
    }
}
