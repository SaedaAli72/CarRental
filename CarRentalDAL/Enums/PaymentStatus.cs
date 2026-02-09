using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Enums
{
    public enum PaymentStatus
    {
        Pending,    // Payment is initiated but not completed yet
        Completed,  // Payment was successful
        Failed      // Payment failed due to an error
    }
}
