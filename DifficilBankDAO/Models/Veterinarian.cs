using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VeterinarySmilesDAO.Models;

namespace DifficilBankDAO.Models
{
    public class Veterinarian : Person
    {

        #region Properties

        public string CodVet { get; set; }
        public string Especialty { get; set; }

        public int UserID { get; set; }


        #endregion

        #region Constructors

        public Veterinarian(int iD, string ci, string name, string firsName, string secondLastName, DateTime birtDate, char gender, string phone, string address, byte status, DateTime registerDate, DateTime lastDate, string codVet, string especialty, int userID) : base(iD, ci, name, firsName, secondLastName, birtDate, gender, status, registerDate, lastDate)
        {
            this.CodVet = codVet;
            this.Especialty = especialty;
            this.UserID = userID;

        }

        public Veterinarian(string ci, string name, string firsName, string secondLastName, DateTime birtDate, char gender, string phone, string address, string codVet, string especialty) : base(ci, name, firsName, secondLastName, birtDate, gender)
        {
            this.CodVet = codVet;
            this.Especialty = especialty;


        }

        public Veterinarian(string codVet, string especialty)
        {
            this.CodVet = codVet;
            this.Especialty = especialty;


        }



        #endregion








    }
}
