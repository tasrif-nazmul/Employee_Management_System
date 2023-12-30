using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ITask<CLASS,ID,RET>
    {
        RET TaskHandle(CLASS obj);
        CLASS Get(ID id);
        List<CLASS> GetAll();
    }
}
