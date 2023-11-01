using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Models;

namespace DifficilBankDAO.Models
{
    public class Supplier : BaseModel
    {
       


        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        #endregion

        #region Constructors

        public Supplier(int id, string name,string phone,string address,string email)
        {
            ID = id;
            Name = name;
            Phone = phone;
            Address = address;
            Email = email;
            
        }

        public Supplier(int iD, string name, string phone, string address,string email, byte status, DateTime registerDate, DateTime lastDate) : base(status, registerDate, lastDate)
        {
            ID = iD;
            Name = name;    
            Phone = phone;
            Address = address;
            Email = email;
        }

        public Supplier(string name, string phone, string address, string email)
        {
            Name = name;
            Phone = phone;
            Address = address;
            Email = email;
        }


        

        #endregion



    }
}
