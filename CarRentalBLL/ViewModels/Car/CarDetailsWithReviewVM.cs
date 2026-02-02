using CarRentalBLL.ViewModels.CarImage;
using CarRentalBLL.ViewModels.Review;
using CarRentalDAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.ViewModels.Car
{
    public class CarDetailsWithReviewVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int ModelYear { get; set; }
        public string Color { get; set; }
        public decimal PricePerDay { get; set; }
        public CarStatus Status { get; set; } //Enum
        public ICollection<CarImageVM> CarImages { get; set; }

        #region Category
        //public string CategoryId { get; set; }
        public CarRentalDAL.Entities.Category Category { get; set; }
        #endregion

        public List<ReviewVM> Reviews { get; set; }
    }
}
