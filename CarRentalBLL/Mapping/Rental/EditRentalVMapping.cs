using CarRentalBLL.ViewModels.Rental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalDAL.Entities;

namespace CarRentalBLL.Mapping.Rental
{
    public static class EditRentalVMapping
    {
        public static void MapToRental(this EditRentalVM editRentalVm, CarRentalDAL.Entities.Rental rental)
        {
               rental.RentalDate = editRentalVm.RentalDate;
               rental.ReturnDate = editRentalVm.ReturnDate;
        }
        public static EditRentalVM MapToEditRentalVM(this CarRentalDAL.Entities.Rental rental)
        {
            return new EditRentalVM
            {
                Id = rental.Id,
                RentalDate = rental.RentalDate,
                ReturnDate = rental.ReturnDate
            };
        }
    }
}
