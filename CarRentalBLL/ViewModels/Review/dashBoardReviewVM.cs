using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.ViewModels.Review
{
   public class dashBoardReviewVM
    {
        public int totalReviews { get; set; }
        public decimal averageReviewsTotal { get; set; }
        public List<AllReviewsVM> allReviews { get; set; }= new List<AllReviewsVM>();
    }
}
