using CarRentalBLL.Services;
using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels;
using CarRentalBLL.ViewModels.Payment;
using CarRentalDAL.Entities;
using CarRentalDAL.Enums;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace CarRentalPL.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentManager _paymentManager;
        private readonly IRentalService _rentalService;
        private readonly IConfiguration _configuration;
        private readonly StripeService _stripeService;

        public PaymentController(
            IConfiguration configuration,
            IPaymentManager paymentManager,
            StripeService stripeService,
            IRentalService rentalService)
        {
            _configuration = configuration;
            _paymentManager = paymentManager;
            _stripeService = stripeService;
            _rentalService = rentalService;
        }

        // GET: Payment/Checkout?rentalId=xxx
        public IActionResult Checkout(Guid rentalId)
        {
                // جلب الـ Rental مع الـ Car
                var rental = _rentalService.GetRentalById(rentalId);

            if (rental == null)
                return NotFound("Rental not found");

            if (rental.Car == null)
                return BadRequest("Car info missing for this rental");

            // التأكد من البيانات
            Console.WriteLine($"DEBUG: RentalId: {rental.Id}");
            Console.WriteLine($"DEBUG: RentalDate: {rental.RentalDate}, ReturnDate: {rental.ReturnDate}");
            Console.WriteLine($"DEBUG: Car.PricePerDay: {rental.Car.PricePerDay}");

            // حساب عدد الأيام
            var days = (rental.ReturnDate - rental.RentalDate).Days;
            if (days <= 0) days = 1;

            // حساب المبلغ
            var amount = rental.Car.PricePerDay * days;

            // تأكد إن المبلغ أكبر من صفر
            if (amount <= 0)
            {
                amount = 1; // بدل ما يرجع صفر
                Console.WriteLine("DEBUG: Amount was zero, forced to 1");
            }

            // تمرير البيانات للـ View
            ViewBag.RentalId = rental.Id;
            ViewBag.Amount = amount.ToString(System.Globalization.CultureInfo.InvariantCulture);
            ViewBag.StripePublishableKey = _configuration["Stripe:PublishableKey"];

            return View();
        }

        [HttpPost]
        public IActionResult CreatePaymentIntent([FromBody] CreatePaymentRequest request)
        {
            try
            {
                Console.WriteLine($"DEBUG: Amount received in POST = {request.Amount}");

                if (request.Amount <= 0)
                {
                    return BadRequest(new { error = "Amount must be greater than zero" });
                }

                var clientSecret = _stripeService.CreatePaymentIntent(request.Amount);

                var payment = new Payment
                {
                    Amount = request.Amount,
                    PaymentDate = DateTime.Now,
                    PaymentType = (PaymentType)request.PaymentType,
                    Status = PaymentStatus.Pending,
                    RentalId = request.RentalId
                };

                var createdPayment = _paymentManager.CreatePayment(payment);

                return Json(new
                {
                    clientSecret = clientSecret,
                    paymentId = createdPayment.Id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        [HttpPost]
        public IActionResult ConfirmPayment([FromBody] ConfirmPaymentRequest request)
        {
            var payment = _paymentManager.GetPaymentById(request.PaymentId);
            if (payment == null)
                return NotFound(new { error = "Payment not found" });

            var isSuccess = _stripeService.ConfirmPayment(request.PaymentIntentId);

            if (isSuccess)
            {
                payment.Status = PaymentStatus.Completed;
                _paymentManager.UpdatePayment(payment);
                return Ok(new { success = true });
            }
            else
            {
                payment.Status = PaymentStatus.Failed;
                _paymentManager.UpdatePayment(payment);
                return BadRequest(new { error = "Payment failed" });
            }
        }


        public IActionResult Success() => View();
        public IActionResult Failed() => View();

        public IActionResult History(Guid rentalId)
        {
            var payments = _paymentManager.GetPaymentsByRentalId(rentalId);
            return View(payments);
        }
    }
}
