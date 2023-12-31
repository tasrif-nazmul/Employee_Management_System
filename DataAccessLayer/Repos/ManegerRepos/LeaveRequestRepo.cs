using DataAccessLayer.EF;
using DataAccessLayer.Interfaces.ManegerInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.ManegerRepos
{
    internal class LeaveRequestRepo : Repo, ILeaveReq<LeaveRequest, int, bool>
    {
        public bool LeaveReqHandle(LeaveRequest obj)
        {

            db.LeaveRequests.AddOrUpdate(obj);
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
    }
}
