﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IPR<CLASS,ID>
    {
        List<CLASS> GetAll();
        CLASS Get(ID id);
    }
}
