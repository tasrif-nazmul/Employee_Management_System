using DataAccessLayer.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=EmployeeManagementSystemEntities")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<AssignedTasks> AssignedTasks { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }

    }
}
