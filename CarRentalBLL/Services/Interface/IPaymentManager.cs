using CarRentalBLL.ViewModels.Payment;
using CarRentalDAL.Entities;
using CarRentalDAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Services.Interface
{
    public interface IPaymentManager
    {
        Payment CreatePayment(Payment payment);
        Payment GetPaymentById(Guid id);
        Payment UpdatePayment(Payment payment);
        List<Payment> GetPaymentsByRentalId(Guid rentalId);
        IQueryable<Paymentcard> GetAllPayments();
    }
}
