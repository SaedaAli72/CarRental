using CarRentalBLL.ViewModels.Review;
using CarRentalDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Mapping.Reviews
{
   public static class allReviewMapping
    {
        public static AllReviewsVM MapToAllReviewsVM(this Review review)
        {
            AllReviewsVM allReviewsVM = new AllReviewsVM()
            {
                Date = review.Date,
                Score = review.Score,
                CustomerName = review.CustomerUser.UserName,
                Title = review.Title ?? "No Review Title",
                CarName=review.Car.Name

               

            };
            return allReviewsVM;
        }
    }
}
