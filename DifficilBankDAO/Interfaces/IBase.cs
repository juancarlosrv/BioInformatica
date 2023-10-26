﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinarySmilesDAO.Interfaces
{
    internal interface IBase<T>
    {
        int Delete(T t);
        int Insert(T t);
        int Update(T t);
        DataTable Select();

    }
}
