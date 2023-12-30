using DataAccessLayer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos
{
    internal class Repo
    {
        internal EmployeeManagementEntities1 db;
        internal Repo()
        {
            db = new EmployeeManagementEntities1();
        }
    }
}
