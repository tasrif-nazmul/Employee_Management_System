using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.EmployeeDTOs
{
    public class AssignedTaskDTO
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int AssignedToID { get; set; }
        public int AssignedByID { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
    }
}
