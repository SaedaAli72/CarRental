using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalBLL.ViewModels.Car;

namespace CarRentalBLL.Mapping.Car
{
    public static class EditCarToCar
    {
        public static void MapToCarEntity(
            this ViewModels.Car.EditCarVM vm,
            CarRentalDAL.Entities.Car car)
        {
            car.Name = vm.Name;
            car.Brand = vm.Brand;
            car.ModelYear = vm.ModelYear;
            car.PlateNumber = vm.PlateNumber;
            car.Color = vm.Color;
            car.Capacity = vm.Capacity;
            car.PricePerDay = vm.PricePerDay;
            car.Status = vm.Status;
            car.CategoryId = vm.CategoryId;
        }


        public static EditCarVM MatpToEditCarVm(this CarRentalDAL.Entities.Car car)
        {
            return new EditCarVM {
                Name = car.Name,
                Brand = car.Brand,
                ModelYear = car.ModelYear,
                PlateNumber = car.PlateNumber,
                Color = car.Color,
                Capacity = car.Capacity,
                PricePerDay = car.PricePerDay,
                Status = car.Status,
                CategoryId = car.CategoryId,
                ExistingImages = car.CarImages?.Select(ci => new ViewModels.CarImage.CarImageVM
                {
                    Id = ci.Id,
                    ImagePath = ci.ImagePath
                }).ToList()
            };
        }
      

    }
}

