using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Mapping.Rental
{
    public static class RentalToCreateRental
    {
        public static ViewModels.Rental.CreateRentalVm MapToCreateRentalVM(this CarRentalDAL.Entities.Rental rental)
        {
            if (rental == null) return null;
            return new ViewModels.Rental.CreateRentalVm
            {
                CarId = rental.CarId,
                RentalDate = rental.RentalDate,
                ReturnDate = rental.ReturnDate,
            };
        }
        public static CarRentalDAL.Entities.Rental MapToRental(this ViewModels.Rental.CreateRentalVm rentalVm)
        {
            if (rentalVm == null) return null;
            return new CarRentalDAL.Entities.Rental
            {
                CarId = rentalVm.CarId,
                RentalDate = rentalVm.RentalDate,
                ReturnDate = rentalVm.ReturnDate,
            };
        }
    }
}
