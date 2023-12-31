using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.EmployeeRepos
{
    internal class AttendanceRepo : Repo, IAttendance<AttendanceRecord, bool>
    {

        public bool CreateEntry(AttendanceRecord obj)
        {
            AttendanceRecord CreateEntry = new AttendanceRecord
            {
                EmployeeID = obj.EmployeeID,
                EntryDateTime = DateTime.Now,
            };
            db.AttendanceRecords.Add(CreateEntry);
            return db.SaveChanges() > 0;
        }
        public bool CreateExit(AttendanceRecord obj)
        {
            db.AttendanceRecords.AddOrUpdate(obj);
            return db.SaveChanges() > 0;
        }

        
    }
}
