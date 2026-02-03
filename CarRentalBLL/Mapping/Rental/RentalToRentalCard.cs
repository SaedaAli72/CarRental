using CarRentalBLL.ViewModels.Rental;
using CarRentalDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Mapping.Rental
{
    public static class RentalToRentalCard
    {
        public static ViewModels.Rental.RentalCardVM MapToRentalCardVM(this CarRentalDAL.Entities.Rental rental)
        {
            if (rental == null) return null;
            return new ViewModels.Rental.RentalCardVM
            {
                Id = rental.Id,
                RentalDate = rental.RentalDate,
                ReturnDate = rental.ReturnDate,
                Status = rental.Status,
                ActualDate = rental.ActualDate,
                CustomerUserId = rental.CustomerUserId,
                CustomerUser = rental.CustomerUser?.UserName,
                OwnerUserId = rental.OwnerUserId,
                OwnerUser = rental.OwnerUser?.UserName,
                Car = rental.Car
            };
        }

        public static CarRentalDAL.Entities.Rental MapToRental(this RentalCardVM rentalVm)
        {
            if(rentalVm == null) return null;
            return new CarRentalDAL.Entities.Rental
            {
                Id = rentalVm.Id,
                RentalDate = rentalVm.RentalDate,
                ReturnDate = rentalVm.ReturnDate,
                Status = rentalVm.Status,
                ActualDate = rentalVm.ActualDate,
                CustomerUserId = rentalVm.CustomerUserId,
                OwnerUserId = rentalVm.OwnerUserId,
                Car = rentalVm.Car

            };
        }
        public static void MapToRental(this RentalCardVM rentalVm, CarRentalDAL.Entities.Rental rental)
        {
            if (rentalVm == null) return;
            rental.RentalDate = rentalVm.RentalDate;
            rental.ReturnDate = rentalVm.ReturnDate;
            rental.Status = rentalVm.Status;
            rental.ActualDate = rentalVm.ActualDate;
            rental.CustomerUserId = rentalVm.CustomerUserId;
            rental.OwnerUserId = rentalVm.OwnerUserId;
            rental.Car = rentalVm.Car;
        }


    }
}
