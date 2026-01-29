using CarRentalDAL.Entities;
using CarRentalDAL.Repositaries.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.UnitOfWork
{
    public interface IUnitOfWork 
    {
        IGenericRepo<Car> cars { get; }
        IGenericRepo<Rental> rentals { get; }
        IGenericRepo<CarImage> carImages { get; }
        IGenericRepo<AppUser> appUsers { get; }
        IGenericRepo<Payment> payments { get; }
        IGenericRepo<UserDocument> userDocuments { get; }
        IGenericRepo<Review> reviews { get; }
        IGenericRepo<Category> categories { get; }
        int Save();
    }
}
