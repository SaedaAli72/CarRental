using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.ViewModels.Rental
{
    public class CreateRentalVm
    {
        public Guid CarId { get; set; }
        public string OwnerId { get; set; }
        [Display(Name = "Pick-up Time")]
        public DateTime RentalDate { get; set; }
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }

        public decimal RentalPricePerDay
        {
            get
            {
                return 1000;
            }
        }
        public decimal AllRentalPrice
        {
            get
            {
                var days = (decimal)(ReturnDate.Subtract(RentalDate).TotalDays);
                return days * RentalPricePerDay;
            }
        }
    }
}
