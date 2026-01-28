using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Repositaries
{
    public class PaymentRepo : GenericRepo<Entities.Payment>, Interface.IPaymentRepo
    {
        public PaymentRepo(Context.AppDBContext context) : base(context)
        {
        }
    
    }
}
