using CarRentalBLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalPL.Controllers
{
    public class PaymentdashboardController : Controller
    {
        private readonly IPaymentManager _paymentManager;

        public PaymentdashboardController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        public IActionResult Index()
        {
            var payments = _paymentManager.GetAllPayments();
            return View("Index", payments);

        }
    }
}
