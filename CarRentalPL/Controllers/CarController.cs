using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Car;
using CarRentalDAL.Entities;
using CarRentalDAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRentalPL.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICaregotyService _categoryService;
        public CarController(ICarService carService, ICaregotyService categoryService)
        {
            _carService = carService;
            _categoryService = categoryService;
        }



        public IActionResult Index(string? searchTerm,int? minPrice)
        {
            searchTerm = searchTerm?.Trim().ToLower();
            Func<Car,bool>? func = null;
            if (!string.IsNullOrEmpty(searchTerm) && minPrice.HasValue)
            {
                func = c => (c.Name.Trim().ToLower().Contains(searchTerm) || c.Brand.Trim().ToLower().Contains(searchTerm)) && c.PricePerDay >= minPrice.Value;
            }
            else if (!string.IsNullOrEmpty(searchTerm))
            {
                func = c => c.Name.Trim().ToLower().Contains(searchTerm) || c.Brand.Trim().ToLower().Contains(searchTerm);
            }
            else if (minPrice.HasValue)
            {
                func = c => c.PricePerDay >= minPrice.Value;
            }
            ViewData["SearchTerm"] = searchTerm;
            ViewData["MinPrice"] = minPrice;


            var cars = _carService.GetAllCars(func);
            return View("index",cars);
        }

        // change return type from carcardvm to CarDetailsWithReviewVM
        public IActionResult Details(Guid id)
        {
            var car = _carService.GetCarById(id);
            return View("Details",car);
        }
        public IActionResult Error()
        {
            return View("Error");
        }
        public IActionResult Remove(Guid id)
        {
           return _carService.RemoveCar(id)? RedirectToAction("Index") : RedirectToAction("Error");
        }
        [HttpGet]
        [Authorize(Roles = "Owner")]    
        public IActionResult Create()
        {
            CreateCarVM carVM = new CreateCarVM();
            carVM.Categories = _categoryService.GetAllCategories(null);
            return View("Create", carVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarRentalBLL.ViewModels.Car.CreateCarVM carVM)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                return _carService.AddCar(carVM,userId) ? RedirectToAction("Index") : RedirectToAction("Error");
            }
            carVM.Categories = _categoryService.GetAllCategories(null);
            return View("Create",carVM);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            EditCarVM carCardvm = _carService.GetCarByIdForEdit(id);

            return View("Edit", carCardvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id , EditCarVM carvm)
        {
            if (ModelState.IsValid)
            {
                _carService.UpdateCar(carvm);
                return RedirectToAction("Index");
            }
            carvm.Categories = _categoryService.GetAllCategories(null);
            return View("Edit", carvm);
        }
         
        
        public bool ChangeCarStatus(Guid CarId,CarStatus carStatus)
        {
            bool carstatus = _carService.ChangeCarStatus(CarId, carStatus);
            if (carstatus)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
