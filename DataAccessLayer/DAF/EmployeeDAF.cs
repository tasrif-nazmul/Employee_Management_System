using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.AdmiInterfaces;
using DataAccessLayer.Repos;
using DataAccessLayer.Repos.EmployeeRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAF
{
    public class EmployeeDAF
    {
        public static ILeaveReq<LeaveRequest, int, bool> LeaveReqData()
        {
            return new LeaveRequestRepo();
        }
        public static IAttendance<int, bool> AttendanceData()
        {
            return new AttendanceRepo();
        }
        public static ITask<AssignedTask, int, bool> AssignedTaskData()
        {
            return new AssignedTaskRepo();
        }

        public static IPR<Payroll,int> PRoleData()
        {
            return new PRRepo();
        }

        public static IAdmin<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
    }
}
