using DataAccessLayer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.EmployeeRepos
{
    public class LeaveRequestRepo
    {
        public static bool Create(LeaveRequest lr)
        {
            var db = new EmployeeManagementEntities();
            db.LeaveRequests.Add(lr);
            return db.SaveChanges() > 0;
        }

        public static List<LeaveRequest> GetAll()
        {
            var db = new EmployeeManagementEntities();
            return db.LeaveRequests.ToList();
        }
    }
}
