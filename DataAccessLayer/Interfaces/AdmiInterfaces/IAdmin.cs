using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.AdmiInterfaces
{
    public interface IAdmin<CLASS,ID,RET>
    {
        List<CLASS> GetAll();
        CLASS Get(ID id);
        RET Add(CLASS obj);
        RET Delete(ID id);
        RET Update(CLASS obj);
    }
}
