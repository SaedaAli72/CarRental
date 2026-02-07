using CarRentalBLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalPL.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            var dashboardHomeVm = _dashboardService.GetDashboardHome();
            return View("Index", dashboardHomeVm);
        }
    }
}
