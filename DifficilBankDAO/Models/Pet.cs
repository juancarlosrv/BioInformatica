using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarySmilesDAO.Models;

namespace VeterinarySmilesDAO.Models
{
    public class Pet : BaseModel
    {
        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime BirtDate { get; set; }
        public double Weigth { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }

        #endregion

        #region Constructors
        public Pet(int id, string name, DateTime birtDate, double weigth, string breed, string color, byte status, DateTime registerDate, DateTime lastDate) : base(status, registerDate, lastDate)
        {
            ID = id;
            Name = name;
            BirtDate = birtDate;
            Weigth = weigth;
            Breed = breed;
            Color = color;
        }
        public Pet(string name, DateTime birtDate, double weigth, string breed, string color)
        {
            Name = name;
            BirtDate = birtDate;
            Weigth = weigth;
            Breed = breed;
            Color = color;
        }

        #endregion

    }
}
