using CarRentalBLL.Mapping.Reviews;
using CarRentalBLL.ViewModels.Car;
using CarRentalDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Mapping.Car
{
    public static class CarToCarCardVM
    {
        public static CarCardVM ToCarCard(this CarRentalDAL.Entities.Car car)
        {
            var carCardVM = new CarCardVM
            {
                Id = car.Id,
                Name = car.Name,
                Brand = car.Brand,
                ModelYear = car.ModelYear,
                Color = car.Color,
                PricePerDay = car.PricePerDay,
                Status = car.Status,
                //CategoryId = car.Category.Id,
                Category = car.Category,
                CarImage = car.CarImages.FirstOrDefault()?.ImagePath,
                
            };
            return carCardVM;
        }

        //public static CarDetailsWithReviewVM ToCarCardWithReview(this CarRentalDAL.Entities.Car car)
        //{
        //    var carCardWithReviewVM = new CarDetailsWithReviewVM()
        //    {
        //        Id = car.Id,
        //        Name = car.Name,
        //        Brand = car.Brand,
        //        ModelYear = car.ModelYear,
        //        Color = car.Color,
        //        PricePerDay = car.PricePerDay,
        //        Status = car.Status,
        //        //CategoryId = car.Category.Id,
        //        Category = car.Category,
        //        CarImage = car.CarImages.FirstOrDefault()?.ImagePath,
        //        Reviews = car.Reviews.Select(r => r.MapToReviewVM()).ToList()
        //    };
        //    return carCardWithReviewVM;
        //}
    }
}
