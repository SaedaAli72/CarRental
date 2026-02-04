using CarRentalBLL.ViewModels.Car;
using CarRentalDAL.Entities;
using CarRentalDAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Services.Interface
{
    public interface ICarService
    {
        ICollection<CarCardVM> GetAllCars(Func<Car, bool>? func);
        CarDetailsWithReviewVM GetCarById(Guid id);
        ICollection<CarCardVM> GetAllAvailableCars(Func<Car, bool>? func);
        bool AddCar(CreateCarVM car,string OwnerId);
        bool RemoveCar(Guid id);
        bool UpdateCar(EditCarVM carvm);
        EditCarVM GetCarByIdForEdit(Guid carId);
        bool ChangeCarStatus(Guid CarId, CarStatus carStatus);
        CarStatus? GetCarStatus(Guid CarId);
        PagedResult<CarCardVM> GetAllCarsPaged(Func<Car, bool>? func = null, int pageNumber = 1, int pageSize = 12);
    }
}
