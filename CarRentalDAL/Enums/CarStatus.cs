using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Enums
{
    public enum CarStatus
    {
        [Display(Name = "Available")]
        Available,

        [Display(Name = "Rented")]
        Rented,

        [Display(Name = "Under Maintenance")]
        Maintenance,

        [Display(Name = "Binding")]
        binding
    }
}
