using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.EmployeeDTOs
{
    public class PayslipDTO
    {
        public int EmployeeID { get; set; } //Employee Table
        public string EmployeeName { get; set; }//Employee Table
        public string Email { get; set; }//Employee Table
        public string Phone { get; set; }//Employee Table
        public int DepartmentID { get; set; }//Employee Table
        public string Position { get; set; }//Employee Table
        public decimal GrossSalary { get; set; } //Payroll Table
        public decimal NetSalary { get; set; }//Payroll Table
        public decimal TaxAmount { get; set; }//Payroll Table
        public decimal Bonus { get; set; }//Payroll Table
        public decimal TotalAmount { get; set; } //Calculated result
    }
}
