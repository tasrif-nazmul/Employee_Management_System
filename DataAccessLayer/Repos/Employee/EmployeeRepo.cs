using DataAccessLayer.EF;
using DataAccessLayer.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.Employee
{
    internal class EmployeeRepo
    {
        public List<AssignedTasks> GetAll()
        {
            var db = new DatabaseContext();
            var data = db.AssignedTasks.ToList();
            return data;
        }
    }
}
