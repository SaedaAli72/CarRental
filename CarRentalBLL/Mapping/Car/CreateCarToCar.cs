using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Mapping.Car
{
    public static class CreateCarToCar
    {
        public static CarRentalDAL.Entities.Car ToCarEntityfromCreate(this ViewModels.Car.CreateCarVM createCarVM)
        {
            return new CarRentalDAL.Entities.Car
            {
                Name = createCarVM.Name,
                Brand = createCarVM.Brand,
                ModelYear = createCarVM.ModelYear,
                PlateNumber = createCarVM.PlateNumber,
                Color = createCarVM.Color,
                Capacity = createCarVM.Capacity,
                PricePerDay = createCarVM.PricePerDay,
                OwnerUserId = createCarVM.OwnerUserId,
                CategoryId = createCarVM.CategoryId,
                CarImages = createCarVM.CarImages
            };
        }
    }
}
