using CarRentalBLL.Mapping.Dashboard;
using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Dashboard;
using CarRentalDAL.Entities;
using CarRentalDAL.Enums;
using CarRentalDAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public DashboardService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public DashboardHomeVm GetDashboardHome()
        {
            DashboardHomeVm dashboardHomeVm = new DashboardHomeVm();
            var rentals = _unitOfWork.rentals.GetAll().Include(r => r.Car).Include(r => r.CustomerUser).Include(r=>r.Car);
            var recentRentals = rentals
                .OrderByDescending(r => r.RentalDate)
                .Select(r=>r.ToRentalVM())
                .Take(5)
                .ToList();
            int totalRentals = rentals.Count();
            int activeRentals = rentals.Where(r => r.Status == RentalStatus.Active).Count();
            var payments = _unitOfWork.payments.GetAll();
            decimal totalRevenue = payments.Sum(p => p.Amount);
            var users = _userManager.Users.ToList();

            int totalCustomers = 0;

            foreach (var user in users)
            {
                if (_userManager.IsInRoleAsync(user, "Customer").Result)
                {
                    totalCustomers++;
                }
            }


            var cars = _unitOfWork.cars.GetAll().Include(c => c.Rentals).Include(c=>c.Category).Include(c => c.CarImages);
            var mostRentedCars = cars
                .OrderByDescending(c => c.Rentals.Count())
                .Select(c => c.MapToCarVM())
                .Take(5)
                .ToList();
            dashboardHomeVm.RecentRentals = recentRentals;
            dashboardHomeVm.TotalRentals = totalRentals;
            dashboardHomeVm.ActiveRentals = activeRentals;
            dashboardHomeVm.TotalRevenue = totalRevenue;
            dashboardHomeVm.TotalCustomers = totalCustomers;
            dashboardHomeVm.MostRentedCars = mostRentedCars;
            return dashboardHomeVm;
        }
    }
}
