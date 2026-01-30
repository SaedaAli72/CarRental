using CarRentalBLL.Mapping.Car;
using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Car;
using CarRentalDAL.Entities;
using CarRentalDAL.Enums;
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
        private readonly IUnitOfWork _unitOfWork;
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
            return _unitOfWork.cars.GetAll().Include(c => c.Category).Include(c => c.CarImages).Select(c => c.ToCarCard()).ToList();
        }
        ICollection<CarCardVM> ICarService.GetAllAvailableCars(Func<Car, bool>? func = null)
        {
            if (func != null)
            {
                return _unitOfWork.cars.GetAll().Where(c => c.Status == CarStatus.Available).Include(c => c.Category).Include(c => c.CarImages).Where(func).Select(c => c.ToCarCard()).ToList();
            }
            return _unitOfWork.cars.GetAll().Where(c => c.Status == CarStatus.Available).Include(c => c.Category).Include(c => c.CarImages).Select(c => c.ToCarCard()).ToList();
        }
        public bool AddCar(CreateCarVM carVM)
        {
            try
            {
                Car car = carVM.ToCarEntityfromCreate();
                _unitOfWork.cars.Add(car);
                return _unitOfWork.Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool RemoveCar(string carId)
        {
            try
            {
                Car car = _unitOfWork.cars.GetById(carId);
                _unitOfWork.cars.Delete(car);
                return _unitOfWork.Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateCar(Car car)
        {
            try
            {
                _unitOfWork.cars.Update(car);
                return _unitOfWork.Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
