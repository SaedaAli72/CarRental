using CarRentalBLL.Mapping.Reviews;
using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Review;
using CarRentalDAL.Entities;
using CarRentalDAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Services
{
    public class ReviewService :IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddReview(CreateReviewVM reviewVm)
        {
            Review review = reviewVm.MapToReviewEntity();
            _unitOfWork.reviews.Add(review);
            return _unitOfWork.Save() > 0;

        }

        public List<ReviewVM> GetCarDetailReviews(Guid carId)
        {
            List<ReviewVM> reviews = _unitOfWork.reviews.GetAll().Include(r=>r.CustomerUser).Where(r=>r.CarId == carId).Select(r=>r.MapToReviewVM()).ToList();
            return reviews;
        }
    }
}
