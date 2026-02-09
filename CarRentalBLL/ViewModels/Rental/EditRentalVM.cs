using CarRentalDAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.ViewModels.Rental
{
     public class EditRentalVM
    {
            public Guid Id { get; set; }
            public DateTime RentalDate { get; set; }
            public DateTime ReturnDate { get; set; }
            public RentalStatus? status { get; set; }
    }
}
