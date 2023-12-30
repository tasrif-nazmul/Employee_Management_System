using DataAccessLayer.EF;
using DataAccessLayer.Interfaces.ManegerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.ManegerRepos
{
    internal class LeaveRequestRepo : Repo, ILeaveReq<LeaveRequest, int, bool>
    {
        public bool Accept(LeaveRequest obj)
        {
            throw new NotImplementedException();
        }

        public LeaveRequest Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<LeaveRequest> GetAll()
        {
            return db.LeaveRequests.ToList();
        }

        public bool Reject(LeaveRequest obj)
        {
            throw new NotImplementedException();
        }
    }
}
