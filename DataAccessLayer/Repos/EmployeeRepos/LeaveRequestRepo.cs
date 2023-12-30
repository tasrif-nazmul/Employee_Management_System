using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.EmployeeRepos
{
    internal class LeaveRequestRepo : Repo, ILeaveReq<LeaveRequest, int, bool>
    {
        public bool Create(LeaveRequest obj)
        {
            db.LeaveRequests.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = db.LeaveRequests.Find(id);
            db.LeaveRequests.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public LeaveRequest Get(int id)
        {
            return db.LeaveRequests.Find(id);

        }

        public List<LeaveRequest> GetAll()
        {
            return db.LeaveRequests.ToList();
        }

        public bool Update(LeaveRequest obj)
        {
            throw new NotImplementedException();
        }
    }
}
