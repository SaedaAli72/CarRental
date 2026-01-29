using CarRentalDAL.Context;
using CarRentalDAL.Entities;
using CarRentalDAL.Repositaries;
using CarRentalDAL.Repositaries.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext context;
        public UnitOfWork(AppDBContext context)
        {
            this.context = context;
            cars = new GenericRepo<Car>(context);
            rentals = new GenericRepo<Rental>(context);
            carImages = new GenericRepo<CarImage>(context);
            appUsers = new GenericRepo<AppUser>(context);
            payments = new GenericRepo<Payment>(context);
            userDocuments = new GenericRepo<UserDocument>(context);
            reviews = new GenericRepo<Review>(context);
            categories = new GenericRepo<Category>(context);

        }

        public IGenericRepo<Car> cars { get; private set; }

        public IGenericRepo<Rental> rentals { get; private set; }

        public IGenericRepo<CarImage> carImages { get; private set; }

        public IGenericRepo<AppUser> appUsers { get; private set; }

        public IGenericRepo<Payment> payments { get; private set; }

        public IGenericRepo<UserDocument> userDocuments { get; private set; }

        public IGenericRepo<Review> reviews { get; private set; }
        public IGenericRepo<Category> categories { get; private set; }

        public int Save()
        {
           return context.SaveChanges();
        }
    }
}
