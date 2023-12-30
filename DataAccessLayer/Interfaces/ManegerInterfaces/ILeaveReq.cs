using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.ManegerInterfaces
{
    public interface ILeaveReq<CLASS, ID, RET>
    {
       
        CLASS Get(ID id);
        List<CLASS> GetAll();
        RET Accept(CLASS obj);
        RET Reject(CLASS obj);
        
    }
}
