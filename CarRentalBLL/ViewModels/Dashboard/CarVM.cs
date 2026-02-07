using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.ViewModels.Dashboard
{
    public class CarVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }
        public int RentalCount { get; set; }

    }
}
