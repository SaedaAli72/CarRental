using CarRentalBLL.Services;
using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Dashboard;
using CarRentalBLL.ViewModels.Rental;
using CarRentalDAL.Entities;
using CarRentalDAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRentalPL.Controllers
{
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;
        private readonly ICarService _carService;

        public RentalController(IRentalService rentalService, ICarService carService)
        {
            _rentalService = rentalService;
            _carService = carService;
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
        [Authorize(Roles ="Customer")]
        public IActionResult Create(Guid id)
        {
            var rentalVm = new CreateRentalVm
            {
                CarId = id,
            };
            return View("_CarRent", rentalVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]

        public IActionResult Create(CreateRentalVm rentalVm)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return RedirectToAction("Error", "Home");
            }
            Rental? createdRental = _rentalService.AddRental(rentalVm, userId);
            if (createdRental is not null)
            {
                bool carstatus = _carService.ChangeCarStatus(rentalVm.CarId, CarStatus.Rented);
                if (carstatus)
                    return RedirectToAction("Checkout", "Payment",new {rentalId = createdRental.Id});
                return RedirectToAction("Error", "Home");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpGet]
        [Authorize(Roles = "Customer")]
        public IActionResult MyRentals() {
            //List<RentalCardVM> rentals = _rentalService.GetAllRentals().ToList();
            //return View("Index", rentals);
            //user`s Id
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<RentalCardVM> rentals = _rentalService.GetUserRentals(userId).ToList();
            return View("MyRentals", rentals);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var rentalVm = _rentalService.GetRentalByIdForEdit(id);
            return View("Edit", rentalVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditRentalVM rentalVm)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = _rentalService.UpdateRental(rentalVm);
                if (isUpdated)
                {
                    return RedirectToAction("MyRentals");
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            return View("Edit", rentalVm);
        }

        public IActionResult ExtendRental(EditRentalVM rentalVm)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = _rentalService.UpdateRental(rentalVm);
                if (isUpdated)
                {
                    return RedirectToAction("MyRentals");
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            return View("Edit", rentalVm);
        }

        public IActionResult CancelRental(Guid rentalId)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = _rentalService.CancelRental(rentalId);
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            return RedirectToAction("Error", "Home");
        }
    }
}