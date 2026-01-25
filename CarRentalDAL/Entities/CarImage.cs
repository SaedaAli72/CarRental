using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Entities
{
    public class CarImage
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        #region Car
        public int CarId { get; set; }
        public Car Car { get; set; } 
        #endregion
    }
}
