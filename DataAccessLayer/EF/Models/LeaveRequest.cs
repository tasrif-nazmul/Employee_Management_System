using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF.Models
{
    public class LeaveRequest
    {
        [Key]
        public int LeaveRequestID { get; set; }
        public string LeaveType { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public string Status { get; set; }

        // Foreign key and navigation property
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
    }

}
