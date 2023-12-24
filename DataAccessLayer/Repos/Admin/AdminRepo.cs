using DataAccessLayer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.Admin
{
    public class AdminRepo
    {
        public static List<Employee> GetAll()
        {
            var db = new EmployeeManagementSystemEntities();
            return db.Employees.ToList();

        }
    }
}
