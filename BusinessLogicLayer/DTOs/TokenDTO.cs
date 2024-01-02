using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class TokenDTO
    {
        public int Id { get; set; }
        public string TKey { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public int EmployeeID { get; set; }
    }
}
