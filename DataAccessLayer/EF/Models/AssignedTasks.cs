using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF.Models
{
    public class AssignedTasks
    {
        [Key]
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }

        // Foreign keys and navigation properties for task assignments
        public int AssignedToID { get; set; }
        public virtual Employee AssignedTo { get; set; }

        public int AssignedByID { get; set; }
        public virtual Employee AssignedBy { get; set; }
    }

}
