using CarRentalDAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        //public decimal AddedCharges { get; set; } // not needed a
        public PaymentType PaymentType { get; set; } //enum =? Deposit - Rent - latefee

        public PaymentStatus Status  {get; set; } //enum =? Pending - Completed - Failed

        #region Rental
        public Guid RentalId { get; set; }
        public Rental Rental { get; set; } 
        #endregion
    }
}
