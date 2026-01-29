using CarRentalBLL.Mapping.Car;
using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Car;
using CarRentalDAL.Entities;
using CarRentalDAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Services
{
    public class CarService : ICarService
    {
        private  readonly IUnitOfWork _unitOfWork;
        public CarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CarCardVM GetCarById(string id)
        {
            return _unitOfWork.cars.GetAll().Include(c => c.Category).Include(c => c.CarImages).FirstOrDefault(c => c.Id == id).ToCarCard();
        }

        ICollection<CarCardVM> ICarService.GetAllCars(Func<Car, bool>? func = null)
        {
            if (func != null)
            {
                return _unitOfWork.cars.GetAll().Include(c => c.Category).Include(c => c.CarImages).Where(func).Select(c => c.ToCarCard()).ToList();
            }
            return _unitOfWork.cars.GetAll().Include(c => c.Category).Include(c=>c.CarImages).Select(c => c.ToCarCard()).ToList();
        }
    }
}
