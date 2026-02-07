using CarRentalBLL.ViewModels.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Mapping.Dashboard
{
    public static class RentalVMMapping
    {
            public static RentalVM ToRentalVM(this CarRentalDAL.Entities.Rental rental)
            {
                return new RentalVM
                {
                    Id = rental.Id,
                    CarName = rental.Car.Name,
                    CustomerName = rental.CustomerUser.UserName ?? "Unknown",
                    RentalDate = rental.RentalDate,
                    ReturnDate = rental.ReturnDate,
                    Status = rental.Status
                };
        }
    }
}
