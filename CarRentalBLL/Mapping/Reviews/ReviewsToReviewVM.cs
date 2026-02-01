using CarRentalBLL.ViewModels.Review;
using CarRentalDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Mapping.Reviews
{
    public static class ReviewsToReviewVM
    {
        public static ReviewVM MapToReviewVM (this Review review)
        {
            ReviewVM reviewVM =new ReviewVM() { 
            Date = review.Date,
            Score = review.Score,
            CustomerName = review.CustomerUser.UserName,
            Text = review.Text,
            Title = review.Title
            
            };
            return reviewVM;
        }

    }
}
