using DataAccessLayer.EF;
using DataAccessLayer.Interfaces.AdmiInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.Admin
{
    internal class AdminRepo : Repo, IAdmin<Employee, int, bool>
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
            db.Employees.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public bool Update(Employee obj)
        {
            var ex = Get(obj.EmployeeID);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

    }
}