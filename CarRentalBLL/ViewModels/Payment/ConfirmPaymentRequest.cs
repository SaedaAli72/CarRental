using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.ViewModels.Payment
{
    public class ConfirmPaymentRequest
    {
        public Guid PaymentId { get; set; }
        public string PaymentIntentId { get; set; }
    }
}
