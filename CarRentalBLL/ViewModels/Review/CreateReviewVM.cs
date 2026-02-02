using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.ViewModels.Review
{
    public class CreateReviewVM
    {
        [Required]
        [Range(1, 5)]
        public int Score { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public string CustomerId { get; set; }
        public Guid CarId { get; set; }
        //public DateTime Date { get; set; }

    }
}
