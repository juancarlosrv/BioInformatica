using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Models;

namespace DifficilBankDAO.Models
{
    public class TypeProduct : BaseModel
    {

        #region Properties
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        #endregion

        #region Constructors
        public TypeProduct(int id, string name, string descriptin, byte status, DateTime registerDate, DateTime lastDate) : base(status, registerDate, lastDate)
        {
            ID = id;         
            Name = name;
            Description = descriptin;
           
        }

        public TypeProduct(string name, string descriptin)
        {
            Name = name;
            Description = descriptin;

        }

        public TypeProduct(int id,string name, string descriptin)
        {
            ID = id;
            Name = name;
            Description = descriptin;

        }
        #endregion
    }
}
