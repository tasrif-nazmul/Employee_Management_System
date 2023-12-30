using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ILeaveReq<CLASS, ID, RET>
    {
        RET Create(CLASS obj);
        CLASS Get(ID id);
        List<CLASS> GetAll();
        RET Update(CLASS obj);
        bool Delete(ID id);
    }
}
