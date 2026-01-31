using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Entities
{
    public class CarImage
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        #region Car
        public Guid CarId { get; set; }
        public Car Car { get; set; } 
        #endregion
    }
}
