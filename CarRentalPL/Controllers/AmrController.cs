using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Car;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalPL.Controllers
{
    public class AmrController : Controller
    {
        private readonly ICarService _carService;

        public AmrController(ICarService carService)
        {
            _carService = carService;
        }
        public IActionResult Index()
        {
            List<CarCardVM> allCars =_carService.GetAllCars(null).ToList();
            return View("index" , allCars);
        }
    }
}
