using CarRentalBLL.ViewModels.Review;
using CarRentalDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Services.Interface
{
    public interface IReviewService
    {
        List<ReviewVM> GetCarDetailReviews(Guid carId);
    }
}
