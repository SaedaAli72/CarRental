using CarRentalBLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalPL.Controllers
{
    public class RentalDashboardController : Controller
    {
        private readonly IRentalService _rentalService;

        public RentalDashboardController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        public IActionResult GetRentalDashboard()
        {
            var rentals = _rentalService.GetAllRentals();
            return View("GetRentalDashboard", rentals);
        }
    }
}
