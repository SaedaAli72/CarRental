using CarRentalBLL.ViewModels.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Services.Interface
{
    public interface IDashboardService
    {
        DashboardHomeVm GetDashboardHome();
    }
}
