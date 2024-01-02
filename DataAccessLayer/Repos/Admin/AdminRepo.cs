using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.AdmiInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.Admin
{
    internal class AdminRepo : Repo, IAdmin<Employee, int, bool>, IAuth<bool>
    {
        public List<Employee> GetAll()
        {

            return db.Employees.ToList();

        }
        public bool Add(Employee obj)
        {
            db.Employees.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = db.Employees.Find(id);
            ex.EmployeeStatus = "Deleted";
            return db.SaveChanges() > 0;
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public bool Update(Employee obj)
        {
            var ex = Get(obj.EmployeeID);

            Employee newEmployee = new Employee()
            {   
                EmployeeID = obj.EmployeeID,
                EmployeeName = string.IsNullOrEmpty(obj.EmployeeName) ? ex.EmployeeName : obj.EmployeeName,
                Email = string.IsNullOrEmpty(obj.Email) ? ex.Email : obj.Email,
                Phone = string.IsNullOrEmpty(obj.Phone) ? ex.Phone : obj.Phone,
                DepartmentID = obj.DepartmentID.HasValue ? ex.DepartmentID : obj.DepartmentID,
                Position = string.IsNullOrEmpty(obj.Position) ? ex.Position : obj.Position,
                EmployeeStatus = string.IsNullOrEmpty(obj.EmployeeStatus) ? ex.EmployeeStatus : obj.EmployeeStatus
            };

            db.Entry(ex).CurrentValues.SetValues(newEmployee);
            return db.SaveChanges() > 0;
        }

        public bool RemoveDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public bool Authenticate(string email, string password)
        {
            var data = db.Employees.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (data != null) return true;
            return false;

        }

        public int GetEmployeeID(string email, string password)
        {
            var employee = db.Employees.FirstOrDefault(e => e.Email == email && e.Password == password);

            if (employee != null)
            {
                return employee.EmployeeID;
            }
            else
            {
                throw new Exception("Invalid Email or Password");
            }
        }


    }
}