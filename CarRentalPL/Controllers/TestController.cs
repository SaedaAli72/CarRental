using CarRentalBLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

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

            var cars = _carService.GetAllAvailableCars(null).Take(3);
            return View("index", cars);
        }
        [Route("test/Error")]
        public IActionResult Error()
        {
            // Optional: get details from HttpContext
            var exceptionFeature = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
            ViewBag.ErrorMessage = exceptionFeature?.Error.Message;
            ViewBag.StatusCode = 500; // default for exceptions
            return View("Error"); // create Views/test/Error.cshtml
        }

        // Handles Status Codes (404, 403, etc.)
        [Route("test/Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            ViewBag.StatusCode = statusCode;
            switch (statusCode)
            {
                case 404:
                    return View("~/Views/Shared/404.cshtml"); // create Views/test/404.cshtml
                default:
                    return View("Error"); // fallback
            }
        }
    }
}
