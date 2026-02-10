using CarRentalBLL.Mapping.Payment;
using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Payment;
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
    public class PaymentManager : IPaymentManager
    {
        private readonly IUnitOfWork _unitOfWork;


        public PaymentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Payment CreatePayment(Payment payment)
        {
          

            _unitOfWork.payments.Add(payment);
            _unitOfWork.Save();

            return payment;
        }

        public Payment GetPaymentById(Guid id)
        {
            return _unitOfWork.payments.GetAll().FirstOrDefault(p => p.Id == id);
        }

        public Payment UpdatePayment(Payment payment)
        {
            _unitOfWork.payments.Update(payment);
            _unitOfWork.Save();

            return payment;
        }
        public IQueryable<Paymentcard> GetAllPayments()
        {
            return _unitOfWork.payments.GetAll().Include(p => p.Rental)
            .ThenInclude(r => r.CustomerUser)
            .Include(p => p.Rental)
            .ThenInclude(r => r.Car).Select(p=>p.MapToPaymentCardVM());
        }

        public List<Payment> GetPaymentsByRentalId(Guid rentalId)
        {
            return _unitOfWork.payments.GetAll()
                .Where(p => p.RentalId == rentalId)
                .OrderByDescending(p => p.PaymentDate)
                .ToList();
        }

       
    }
}
