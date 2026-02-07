using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.ViewModels.Dashboard
{
    public class DashboardHomeVm
    {
        public List<RentalVM> RecentRentals { get; set; }
        public int TotalRentals { get; set; }
        public int ActiveRentals { get; set;}
        public decimal TotalRevenue { get; set; }
        public int TotalCustomers { get; set; }
        public List<CarVM> MostRentedCars { get; set; }
    }
}
