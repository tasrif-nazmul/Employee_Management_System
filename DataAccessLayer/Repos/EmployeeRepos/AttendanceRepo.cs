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
    internal class AttendanceRepo : Repo, IAttendance<int, bool>
    {
        public bool CreateEntry(int id)
        {

            bool employeeExists = db.Employees.Any(e => e.EmployeeID == id);

            if (!employeeExists)
            {
                return false;
            }

            AttendanceRecord existingRecord = db.AttendanceRecords.FirstOrDefault(a => a.EmployeeID == id);

            if (existingRecord != null)
            {
                existingRecord.EntryDateTime = DateTime.Now;
            }
            else
            {
                AttendanceRecord newEntry = new AttendanceRecord
                {
                    EmployeeID = id,
                    EntryDateTime = DateTime.Now,
                };

                db.AttendanceRecords.Add(newEntry);
            }

            return db.SaveChanges() > 0;
        }

        public bool CreateExit(int id)
        {
            bool employeeExists = db.Employees.Any(e => e.EmployeeID == id);

            if (!employeeExists)
            {
                return false;
            }

            // Check if there is an unmarked entry for the employee
            AttendanceRecord existingRecord = db.AttendanceRecords.FirstOrDefault(a => a.EmployeeID == id && a.EntryDateTime != null && a.ExitDateTime == null);

            if (existingRecord != null)
            {
                // An unmarked entry exists, update the exit time
                existingRecord.ExitDateTime = DateTime.Now;
            }
            else
            {
                // No unmarked entry found, return false or handle the case accordingly
                return false;
            }

            return db.SaveChanges() > 0;
        }


    }
}
