using CarRentalBLL.ViewModels.Rental;
using CarRentalDAL.Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Services.Interface
{
    public interface IRentalService
    {
        ICollection<RentalCardVM> GetAllRentals();
        RentalCardVM GetRentalById(Guid id);
        bool AddRental(CreateRentalVm rental, string userId);
        bool RemoveRental(Guid id);
        ICollection<RentalCardVM> GetUserRentals(string userId);
        ICollection<RentalCardVM> GetAllCarRentals(Guid carId);
        public bool UpdateRental(EditRentalVM rentalVm);
        public EditRentalVM GetRentalByIdForEdit(Guid id);
    }
}
