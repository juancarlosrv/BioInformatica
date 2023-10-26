using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Models;

namespace VeterinarySmilesDAO.Interfaces
{
    internal interface IPet : IBase<Pet>
    {
        Pet Get(int id);
    }
}
