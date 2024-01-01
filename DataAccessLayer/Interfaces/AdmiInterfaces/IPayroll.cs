using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.AdmiInterfaces
{
    public interface IPayroll<CLASS, ID, RET>
    {
        RET Add(CLASS obj);
        RET Delete(ID id);
    }
}
