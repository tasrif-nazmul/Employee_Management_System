using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF.Models
{
    public class AttendanceRecord
    {
        [Key]
        public int AttendanceID { get; set; }
        public DateTime EntryDateTime { get; set; }
        public DateTime ExitDateTime { get; set; }

        // Foreign key and navigation property
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
    }

}
