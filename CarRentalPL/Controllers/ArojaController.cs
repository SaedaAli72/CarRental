using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Review;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalPL.Controllers
{
    public class ArojaController : Controller
    {
       private  readonly IReviewService _reviewService;
      

        public ArojaController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public IActionResult Index()
        {

            dashBoardReviewVM dashBoardReview = _reviewService.GetDashBoardReview();


            return View("index", dashBoardReview);
        }
    }
}
