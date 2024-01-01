using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.ManegerInterfaces
{
    
        public interface IPerReview<CLASS, ID, RET,RET1>
        {
            RET Create(CLASS obj);
            List<CLASS> GetAll();
            RET create(CLASS obj);
            bool Delete(ID id);
            RET RemoveAllById(ID id);
            RET1 GetRatings(ID id);
        }
    
}
