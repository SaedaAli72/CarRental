using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.ViewModels
{
    public class CreatePaymentRequest
    {
        public Guid RentalId { get; set; }
        public decimal Amount { get; set; }
        public int PaymentType { get; set; }
    }
}
