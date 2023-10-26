using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Models;

namespace DifficilBankDAO.Models
{
    public class VeterinaryProduct : BaseModel
    {
        
        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public int IdTypeProduct { get; set; }
        public int IdSupplier { get; set; }

        #endregion

        public VeterinaryProduct(int iD, string name, int stock, double price, int idTypeProduct, int idSupplier, byte status, DateTime registerDate, DateTime lastDate) : base(status, registerDate, lastDate)
        {
            ID = iD;
            Name = name;
            Stock = stock;
            Price = price;
            IdTypeProduct = idTypeProduct;
            IdSupplier = idSupplier;
        }

        public VeterinaryProduct( string name, int stock, double price, int idTypeProduct, int idSupplier)
        {
          
            Name = name;
            Stock = stock;
            Price = price;
            IdTypeProduct = idTypeProduct;
            IdSupplier = idSupplier;
        }

    }
}
