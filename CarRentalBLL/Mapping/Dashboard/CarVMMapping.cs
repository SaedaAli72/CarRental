using CarRentalBLL.ViewModels.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Mapping.Dashboard
{
    public static class CarVMMapping
    {
        public static CarVM MapToCarVM(this CarRentalDAL.Entities.Car car)
        {
            return new CarVM
            {
                Id = car.Id,
                Name = car.Name,
                Category = car.Category.Name,
                ImagePath = car.CarImages?.FirstOrDefault()?.ImagePath ?? string.Empty,
                RentalCount = car.Rentals.Count()
            };
        }
    }
}
