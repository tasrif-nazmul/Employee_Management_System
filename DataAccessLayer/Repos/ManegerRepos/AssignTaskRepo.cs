using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.ManegerInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.ManegerRepos
{
    internal class AssignTaskRepo : Repo, IAssignTask<AssignedTask, int, bool>
    {
        
        public bool create(AssignedTask obj)
        {
            AssignedTask newAssignedTask = new AssignedTask()
            {
                TaskName = obj.TaskName,
                Description = obj.Description,
                DueDate = obj.DueDate,
                AssignedToID = obj.AssignedToID,
                AssignedByID = obj.AssignedByID,
                Status = "Pending",
                Priority = obj.Priority

            };
            db.AssignedTasks.Add(newAssignedTask);
            return db.SaveChanges() > 0;
        }


        public bool ReassignTask(AssignedTask assignedTask, int newAssigneeId)
        {
       
            var ex = db.AssignedTasks.Find(assignedTask.TaskID);

            ex.AssignedToID = newAssigneeId;
            ex.AssignedByID = newAssigneeId;

            return db.SaveChanges()>0;
        }

    }
}
