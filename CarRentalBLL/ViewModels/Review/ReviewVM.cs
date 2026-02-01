using CarRentalDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.ViewModels.Review
{
    public class ReviewVM
    {
        public  int Score { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date {  get; set; }

    }
}
