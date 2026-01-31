using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Rental;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRentalPL.Controllers
{
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        public IActionResult Index()
        {
            List<RentalCardVM> rentals = _rentalService.GetAllRentals().ToList();
            return View("Index",rentals);
        }

        public IActionResult Details(Guid id)
        {
            var rental = _rentalService.GetRentalById(id);
            return View("Details",rental);
        }
        [HttpGet]
        public IActionResult Create(Guid carId)
        {
            var rentalVm = new CreateRentalVm
            {
                CarId = carId
            };
            return View("Create", rentalVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateRentalVm rentalVm)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return RedirectToAction("Error", "Home");
            }
            bool isCreated = _rentalService.AddRental(rentalVm, userId);
            if (isCreated)
            {
                return RedirectToAction("Index", "Car");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
