using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repos.EmployeeRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccessFactory
    {
        public static ILeaveReq<LeaveRequest, int, bool> LeaveReqData()
        {
            return new LeaveRequestRepo();
        }
        public static IAttendance<AttendanceRecord, bool> AttendanceData()
        {
            return new AttendanceRepo();
        }
        public static ITask<AssignedTask,int,bool> AssignedTaskData()
        {
            return new AssignedTaskRepo();
        }

    }
}
