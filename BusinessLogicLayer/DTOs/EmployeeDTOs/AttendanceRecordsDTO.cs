using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.EmployeeDTOs
{
    public class AttendanceRecordsDTO
    {
        public int AttendanceId { get; set; }
        public int EmployeeID { get; set;}
        public DateTime EntryDateTime { get; set;}
        public DateTime ExitDateTime { get; set;}

    }
}
