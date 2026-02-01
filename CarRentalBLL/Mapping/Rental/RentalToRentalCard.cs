using CarRentalBLL.ViewModels.Rental;
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
                RentalDate = rental.RentalDate,
                ReturnDate = rental.ReturnDate,
                Status = rental.Status,
                ActualDate = rental.ActualDate,
                CustomerUserId = rental.CustomerUserId,
                OwnerUserId = rental.OwnerUserId
            };
        }

        public static CarRentalDAL.Entities.Rental MapToRental(this RentalCardVM rentalVm)
        {
            if(rentalVm == null) return null;
            return new CarRentalDAL.Entities.Rental
            {
                RentalDate = rentalVm.RentalDate,
                ReturnDate = rentalVm.ReturnDate,
                Status = rentalVm.Status,
                ActualDate = rentalVm.ActualDate,
                CustomerUserId = rentalVm.CustomerUserId,
                OwnerUserId = rentalVm.OwnerUserId
            };
        }

    }
}
