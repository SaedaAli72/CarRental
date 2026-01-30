using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Car;
using CarRentalDAL.Entities;
using Microsoft.AspNetCore.Mvc;

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


            var cars = _carService.GetAllAvailableCars(func);
            return View("index",cars);
        }
        public IActionResult Details(string id)
        {
            var car = _carService.GetCarById(id);
            return View("Details",car);
        }
        public IActionResult Error()
        {
            return View("Error");
        }
        public IActionResult Remove(string id)
        {
           return _carService.RemoveCar(id)? RedirectToAction("Index") : RedirectToAction("Error");
        }
        [HttpGet]
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
                return _carService.AddCar(carVM) ? RedirectToAction("Index") : RedirectToAction("Error");
            }
            return View("Create",carVM);
        }   
    }

}
