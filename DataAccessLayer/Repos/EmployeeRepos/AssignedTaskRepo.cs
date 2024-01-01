using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.EmployeeRepos
{
    internal class AssignedTaskRepo : Repo, ITask<AssignedTask,int, bool>
    {
        public AssignedTask Get(int id)
        {
            var data = db.AssignedTasks.Find(id);
            return data;
        }

        public List<AssignedTask> GetAll()
        {
            return db.AssignedTasks.Where(t => t.Status == "Pending" || t.Status == "In Progress").ToList();
        }

        public bool TaskHandle(AssignedTask obj)
        {
            db.AssignedTasks.AddOrUpdate(obj);
            return db.SaveChanges() > 0;
        }

        public List<AssignedTask> GetAllById(int id)
        {
            return db.AssignedTasks.Where(t => t.AssignedToID == id || t.AssignedByID == id).ToList();
 
        }
    }
}
