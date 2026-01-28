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
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        //public decimal AddedCharges { get; set; } // not needed 
        public PaymentType PaymentType { get; set; } //enum =? Deposit - Rent - latefee

      

        #region Rental
        public string RentalId { get; set; }
        public Rental Rental { get; set; } 
        #endregion
    }
}
