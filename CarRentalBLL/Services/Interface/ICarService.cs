using CarRentalBLL.ViewModels.Car;
using CarRentalDAL.Entities;
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
        CarCardVM GetCarById(string id);
        
    }
}
