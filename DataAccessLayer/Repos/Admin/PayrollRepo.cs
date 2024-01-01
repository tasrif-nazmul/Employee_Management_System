using DataAccessLayer.EF;
using DataAccessLayer.Interfaces.AdmiInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repos.Admin
{
    internal class PayrollRepo : Repo, IPayroll<Payroll, int, bool>
    {
        public bool Add(Payroll obj)
        {
            db.Payrolls.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var payroll = db.Payrolls.Where(t => t.EmployeeID == id).ToList();

            db.Payrolls.RemoveRange(payroll);

            return db.SaveChanges() > 0;
        }
    }
}
