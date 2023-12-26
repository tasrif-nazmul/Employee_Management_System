using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF.Models
{
    public class PerformanceReview
    {
        [Key]
        public int ReviewID { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Feedback { get; set; }
        public decimal Rating { get; set; }

        // Foreign keys and navigation properties
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        public int ReviewerID { get; set; }
        public virtual Employee Reviewer { get; set; }
    }

}
