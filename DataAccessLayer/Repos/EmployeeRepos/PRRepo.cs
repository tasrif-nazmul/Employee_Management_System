using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.EmployeeRepos
{
    internal class PRRepo : Repo, IPR<Payroll,int>
    {
        public Payroll Get(int id)
        {
            return db.Payrolls.Find(id);
        }

        public List<Payroll> GetAll()
        {
            return db.Payrolls.ToList();
        }
    }
}
