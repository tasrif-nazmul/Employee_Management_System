using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        // Navigation property for the team leader
        public int TeamLeaderID { get; set; }
        public virtual Employee TeamLeader { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }

}
