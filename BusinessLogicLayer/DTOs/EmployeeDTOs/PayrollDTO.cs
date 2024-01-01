using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.EmployeeDTOs
{
    public class PayrollDTO
    {
        public int PayrollID { get; set; }
        public int EmployeeID { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
        public decimal TaxAmount { get; set; }
        public DateTime PayDate { get; set; }
        public decimal Bonus { get; set; }
    }
}
