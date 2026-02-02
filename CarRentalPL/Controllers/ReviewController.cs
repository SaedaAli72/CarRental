using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Review;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [HttpGet]
        public IActionResult AddReview(Guid carId)
        {
            CreateReviewVM reviewVm = new CreateReviewVM();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            reviewVm.CustomerId = userId;
            reviewVm.CarId = carId;
            return View("AddReview", reviewVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddReview(CreateReviewVM reviewVm)
        {
            if (!ModelState.IsValid)
            {
                return View("AddReview", reviewVm);
            }
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            reviewVm.CustomerId = userId;
            bool isAdded = _reviewService.AddReview(reviewVm);
            if (isAdded)
            {
                return RedirectToAction("Details", "Car", new { id = reviewVm.CarId });
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
