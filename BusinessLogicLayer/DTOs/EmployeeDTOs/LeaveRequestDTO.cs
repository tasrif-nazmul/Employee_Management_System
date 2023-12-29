using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.EmployeeDTOs
{
    public class LeaveRequestDTO
    {
        public int LeaveRequestID { get; set; }
        public int EmployeeID { get; set; }
        public string LeaveType { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public string Status { get; set; }
    }
}
