using CarRentalDAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.ViewModels.Payment
{
    public class Paymentcard
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus Status { get; set; } 

        public string CustomerUser { get; set; }

        #region Rental
        public Guid RentalId { get; set; }
        public CarRentalDAL.Entities.Rental Rental { get; set; }
        #endregion
    }
}
