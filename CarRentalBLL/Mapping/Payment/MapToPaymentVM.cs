using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Mapping.Payment
{
    public static class MapToPaymentVM
    {
        public static ViewModels.Payment.Paymentcard MapToPaymentCardVM(this CarRentalDAL.Entities.Payment payment)
        {
            if (payment == null) return null;
            return new ViewModels.Payment.Paymentcard
            {
                Id = payment.Id,
                Amount = payment.Amount,
                PaymentType = payment.PaymentType,
                Status = payment.Status,
                RentalId = payment.RentalId,
                PaymentDate = payment.PaymentDate,
                CustomerUser = payment.Rental.CustomerUser.UserName,
                Rental = payment.Rental
            };
        }
    }
}
