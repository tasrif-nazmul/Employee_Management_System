using DataAccessLayer.EF;
using DataAccessLayer.Interfaces.AdmiInterfaces;
using DataAccessLayer.Repos.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAF
{
    public class AdminDAF
    {
        public static IAdmin<Employee, int, bool> EmployeeData()
        {
            return new AdminRepo();
        }
        public static IPayroll<Payroll, int, bool> PayrollData()
        {
            return new PayrollRepo();
        }
    }
}
