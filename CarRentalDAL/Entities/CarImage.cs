using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Entities
{
    public class CarImage
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Description { get; set; }
        public string ImagePath { get; set; }

        #region Car
        public string CarId { get; set; }
        public Car Car { get; set; } 
        #endregion
    }
}
