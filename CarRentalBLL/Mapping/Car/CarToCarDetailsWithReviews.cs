using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalBLL.ViewModels.Car;
using CarRentalBLL.ViewModels.CarImage;
using CarRentalDAL.Entities;

namespace CarRentalBLL.Mapping.Car
{
    public static class CarToCarDetailsWithReviews
    {
        public static CarDetailsWithReviewVM MapToCarDetailsWithReviewVM(this CarRentalDAL.Entities.Car car)
        {
            return new CarDetailsWithReviewVM
            {
                Id = car.Id,
                Name = car.Name,
                Brand = car.Brand,
                ModelYear = car.ModelYear,
                Color = car.Color,
                PricePerDay = car.PricePerDay,
                Status = car.Status,
                Category = car.Category,
                Capacity = car.Capacity,
                
                CarImages =car.CarImages?.Select(ci => new ViewModels.CarImage.CarImageVM
                {
                    Id = ci.Id,
                    ImagePath = ci.ImagePath
                }).ToList(),


            };
        }
    }
}
