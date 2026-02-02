using CarRentalBLL.ViewModels.Review;
using CarRentalDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Mapping.Reviews
{
    public static class CreateReviewMapping
    {
        public static Review MapToReviewEntity(this CreateReviewVM reviewVm)
        {
            return new Review
            {
                Id = Guid.NewGuid(),
                Score = reviewVm.Score,
                Title = reviewVm.Title,
                Text = reviewVm.Text,
                CustomerUserId = reviewVm.CustomerId,
                CarId = reviewVm.CarId,
                Date = DateTime.UtcNow
            };
        }
    }
}
