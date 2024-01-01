using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAttendance<ID, RET>
    {
        RET CreateEntry(ID id);
        RET CreateExit(ID id);

        RET RemoveAllById(ID id);
    }
}
