using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.EmployeeDTOs
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DepartmentID { get; set; }
        public string Position { get; set; }
    }
}
