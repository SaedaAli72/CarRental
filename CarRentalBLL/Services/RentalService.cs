using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Rental;
using CarRentalDAL.Entities;
using CarRentalDAL.UnitOfWork;
using CarRentalBLL.Mapping.Rental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarRentalDAL.Enums;

namespace CarRentalBLL.Services
{
    public class RentalService : IRentalService
    {

        private readonly IUnitOfWork _unitOfWork;
        public RentalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddRental(CreateRentalVm rentalVm, string userId)
        {
            Rental rental = rentalVm.MapToRental();

            var car = _unitOfWork.cars.GetById(c => c.Id == rentalVm.CarId);
            if (car == null)
            {
                
                return false;
            }

            string OwnerId = car.OwnerUserId;
            rental.CustomerUserId = userId;
            rental.OwnerUserId = OwnerId;
            //car.Status =CarStatus.Rented;
            _unitOfWork.rentals.Add(rental);
            return _unitOfWork.Save() > 0;

        }

        public ICollection<RentalCardVM> GetAllCarRentals(Guid carId)
        {
            ICollection<RentalCardVM> rentalCardVMs = _unitOfWork.rentals.GetAll()
                .Include(r => r.Car)
                .Include(r => r.CustomerUser)
                .Where(r => r.CarId == carId)
                .Select(r => r.MapToRentalCardVM())
                .ToList();

            return rentalCardVMs;
        }

        public ICollection<RentalCardVM> GetAllRentals()
        {
            ICollection<RentalCardVM> rentalCardVMs = _unitOfWork.rentals.GetAll()
                .Include(r => r.Car)
                .Include(r => r.CustomerUser)
                .Select(r => r.MapToRentalCardVM())
                .ToList();

            return rentalCardVMs;
        }

        public RentalCardVM GetRentalById(Guid id)
        {
            RentalCardVM rentalCardVM = _unitOfWork.rentals
                                .GetById(r => r.Id == id, r => r.Car, r => r.CustomerUser)
                                .MapToRentalCardVM();

            return rentalCardVM;
        }

        public ICollection<RentalCardVM> GetUserRentals(string userId)
        {
            ICollection<RentalCardVM> rentalCardVMs = _unitOfWork.rentals.GetAll()
                .Include(r => r.Car)
                .Include(r => r.CustomerUser)
                .Where(r => r.CustomerUserId == userId)
                .Select(r => r.MapToRentalCardVM())
                .ToList();

            return rentalCardVMs;
        }

        public bool RemoveRental(Guid id)
        {
            Rental rental = _unitOfWork.rentals.GetById(r => r.Id == id);
            _unitOfWork.rentals.Delete(rental);
            return _unitOfWork.Save() > 0;
        }
    }
}
