using CarRentalBLL.Mapping.Reviews;
using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Review;
using CarRentalDAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Services
{
    internal class ReviewService :IReviewService
    {
        private readonly UnitOfWork _unitOfWork;

        public ReviewService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ReviewVM> GetCarDetailReviews(Guid carId)
        {
            List<ReviewVM> reviews = _unitOfWork.reviews.GetAll().Include(r=>r.CustomerUser).Where(r=>r.CarId == carId).Select(r=>r.MapToReviewVM()).ToList();
            return reviews;

        }
    }
}
