using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.ManegerInterfaces
{
    public interface IAssignTask<CLASS, ID, RET>
    {
        RET create(CLASS obj);
        RET ReassignTask(CLASS obj, ID id);
    }
}
