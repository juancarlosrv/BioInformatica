using DifficilBankDAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Interfaces;
using VeterinarySmilesDAO.Models;

namespace DifficilBankDAO.Interfaces
{
    internal interface IVeterinarian : IBase<Veterinarian>
    {


        //DataTable Login(string userName, string password);

        Veterinarian Get(int id);
        void Insert(Person p, Veterinarian v);



    }
}
