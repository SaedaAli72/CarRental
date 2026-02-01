using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Review;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalPL.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public IActionResult CarDetailsReviews (Guid carId)
        {
            List<ReviewVM> reviews = _reviewService.GetCarDetailReviews(carId);
            return View("CarDetailsReviews",reviews);
        }
    }
}
