using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Models;

namespace DifficilBankDAO.Models
{
    public class Vacunation : BaseModel
    {
        
        #region Properties
        public int ID { get; set; }
        public int IdPet { get; set; }
        public int IdVaccine { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }


        #endregion

        #region constructor
        public Vacunation(int iD, int idPet, int idVaccine, DateTime date, string description, byte status, DateTime registerDate, DateTime lastDate) : base(status, registerDate, lastDate)
        {
            ID = iD;   
            IdPet = idPet;
            IdVaccine = idVaccine;
            Date = date;
            Description = description;
        }

        public Vacunation(int idPet, int idVaccine, DateTime date, string description) { 

            IdPet = idPet;
            IdVaccine = idVaccine;
            Date = date;
            Description = description;
        }
        #endregion
    }
}
