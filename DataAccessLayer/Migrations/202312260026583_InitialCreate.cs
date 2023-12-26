namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignedTasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        Description = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        Priority = c.String(),
                        AssignedToID = c.Int(nullable: false),
                        AssignedByID = c.Int(nullable: false),
                        Employee_EmployeeID = c.Int(),
                        AssignedBy_EmployeeID = c.Int(),
                        AssignedTo_EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeID)
                .ForeignKey("dbo.Employees", t => t.AssignedBy_EmployeeID)
                .ForeignKey("dbo.Employees", t => t.AssignedTo_EmployeeID)
                .Index(t => t.Employee_EmployeeID)
                .Index(t => t.AssignedBy_EmployeeID)
                .Index(t => t.AssignedTo_EmployeeID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Position = c.String(),
                        DepartmentID = c.Int(nullable: false),
                        Department_DepartmentID = c.Int(),
                        Department_DepartmentID1 = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentID)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentID1)
                .Index(t => t.Department_DepartmentID)
                .Index(t => t.Department_DepartmentID1);
            
            CreateTable(
                "dbo.AttendanceRecords",
                c => new
                    {
                        AttendanceID = c.Int(nullable: false, identity: true),
                        EntryDateTime = c.DateTime(nullable: false),
                        ExitDateTime = c.DateTime(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        TeamLeaderID = c.Int(nullable: false),
                        TeamLeader_EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Employees", t => t.TeamLeader_EmployeeID)
                .Index(t => t.TeamLeader_EmployeeID);
            
            CreateTable(
                "dbo.LeaveRequests",
                c => new
                    {
                        LeaveRequestID = c.Int(nullable: false, identity: true),
                        LeaveType = c.String(),
                        LeaveStartDate = c.DateTime(nullable: false),
                        LeaveEndDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeaveRequestID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.PerformanceReviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        ReviewDate = c.DateTime(nullable: false),
                        Feedback = c.String(),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeID = c.Int(nullable: false),
                        ReviewerID = c.Int(nullable: false),
                        Employee_EmployeeID = c.Int(),
                        Reviewer_EmployeeID = c.Int(),
                        Employee_EmployeeID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeID)
                .ForeignKey("dbo.Employees", t => t.Reviewer_EmployeeID)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeID1)
                .Index(t => t.Employee_EmployeeID)
                .Index(t => t.Reviewer_EmployeeID)
                .Index(t => t.Employee_EmployeeID1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignedTasks", "AssignedTo_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.AssignedTasks", "AssignedBy_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.AssignedTasks", "Employee_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.PerformanceReviews", "Employee_EmployeeID1", "dbo.Employees");
            DropForeignKey("dbo.PerformanceReviews", "Reviewer_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.PerformanceReviews", "Employee_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.LeaveRequests", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Department_DepartmentID1", "dbo.Departments");
            DropForeignKey("dbo.Departments", "TeamLeader_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Department_DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.AttendanceRecords", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.PerformanceReviews", new[] { "Employee_EmployeeID1" });
            DropIndex("dbo.PerformanceReviews", new[] { "Reviewer_EmployeeID" });
            DropIndex("dbo.PerformanceReviews", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.LeaveRequests", new[] { "EmployeeID" });
            DropIndex("dbo.Departments", new[] { "TeamLeader_EmployeeID" });
            DropIndex("dbo.AttendanceRecords", new[] { "EmployeeID" });
            DropIndex("dbo.Employees", new[] { "Department_DepartmentID1" });
            DropIndex("dbo.Employees", new[] { "Department_DepartmentID" });
            DropIndex("dbo.AssignedTasks", new[] { "AssignedTo_EmployeeID" });
            DropIndex("dbo.AssignedTasks", new[] { "AssignedBy_EmployeeID" });
            DropIndex("dbo.AssignedTasks", new[] { "Employee_EmployeeID" });
            DropTable("dbo.PerformanceReviews");
            DropTable("dbo.LeaveRequests");
            DropTable("dbo.Departments");
            DropTable("dbo.AttendanceRecords");
            DropTable("dbo.Employees");
            DropTable("dbo.AssignedTasks");
        }
    }
}
