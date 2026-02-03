using CarRentalBLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarRentalPL.Controllers
{
    public class TestController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICaregotyService _categoryService;

        public TestController(ICaregotyService categoryService, ICarService carService)
        {
            _categoryService = categoryService;
            _carService = carService;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var cars = _carService.GetAllCars(null).Take(3);
            return View("index", cars);
        }
    }
}
