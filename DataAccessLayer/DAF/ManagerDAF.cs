using DataAccessLayer.EF;
using DataAccessLayer.Interfaces.ManegerInterfaces;
using DataAccessLayer.Repos.ManegerRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAF
{
    public class ManagerDAF
    {
        public static ILeaveReq<LeaveRequest, int, bool> LRData()
        {
            return new LeaveRequestRepo();
        } 

        public static IAssignTask<AssignedTask,int,bool> ATData()
        {
            return new AssignTaskRepo();
        }

    }
}
