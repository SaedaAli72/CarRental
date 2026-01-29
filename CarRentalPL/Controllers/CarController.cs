using CarRentalBLL.Services.Interface;
using CarRentalDAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalPL.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
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
        public IActionResult Details(string id)
        {
            var car = _carService.GetCarById(id);
            return View("Details",car);
        }
    }
}
