using CarRentalBLL.Services;
using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Car;
using CarRentalBLL.ViewModels.Review;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace CarRentalPL.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        private readonly IPaymentManager paymentManager;
        private readonly IRentalService rentalService;
        private readonly IReviewService reviewService;
        private readonly ICarService carService;


        public DashboardController(IDashboardService dashboardService, IPaymentManager paymentManager, IRentalService rentalService, IReviewService reviewService, ICarService carService)
        {
            _dashboardService = dashboardService;
            this.paymentManager = paymentManager;
            this.rentalService = rentalService;
            this.reviewService = reviewService;
            this.carService = carService;
        }

        public IActionResult Index()
        {
            var dashboardHomeVm = _dashboardService.GetDashboardHome();
            return View("Index", dashboardHomeVm);
        }
        public IActionResult GetPayment()
        {
            var payments = paymentManager.GetAllPayments();
            return View("GetPayment", payments);

        }
        public IActionResult GetRentalDashboard()
        {
            var rentals = rentalService.GetAllRentals();
            return View("GetRentalDashboard", rentals);
        }
        public IActionResult ReviewDashboard()
        {

            dashBoardReviewVM dashBoardReview = reviewService.GetDashBoardReview();


            return View("ReviewDashboard", dashBoardReview);
        }
        public IActionResult CarDashboard()
        {
            List<CarCardVM> allCars = carService.GetAllCars(null).ToList();
            return View("CarDashboard", allCars);
        }
    }
}
