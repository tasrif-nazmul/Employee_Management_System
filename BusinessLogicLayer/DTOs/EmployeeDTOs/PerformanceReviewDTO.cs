using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.EmployeeDTOs
{
            public class PerformanceReviewDTO
            {
                public int ReviewID { get; set; }
                public int EmployeeID { get; set; }
                public DateTime ReviewDate { get; set; }
                public int ReviewerID { get; set; }
                public string Feedback { get; set; }
                public decimal Rating { get; set; }
            }
    
}
