using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalBLL.ViewModels.CarImage;
using CarRentalBLL.ViewModels.Category;
using CarRentalDAL.Entities;
using CarRentalDAL.Enums;
using Microsoft.AspNetCore.Http;

namespace CarRentalBLL.ViewModels.Car
{
    public class EditCarVM
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Brand { get; set; }
        [Range(2000, 2026)]
        public int ModelYear { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public int Capacity { get; set; }
        //[Range(0, 5)]
        //public decimal Rate { get; set; } //to car from all user
        [Range(0, 3000)]
        public decimal PricePerDay { get; set; }
        public CarStatus Status { get; set; } //Enum

        #region OwnerUser
        //public string OwnerUserId { get; set; }
        //public AppUser OwnerUser { get; set; }
        #endregion

        #region Category

        [Display(Name = "Category")]
        public Guid CategoryId { get; set; }
        //public Category Category { get; set; }
        #endregion
        public List<IFormFile>? CarImages { get; set; }
        public List<string>? DeletedImageIds { get; set; }   //  
        public List<CarImageVM>? ExistingImages { get; set; } // 
        public ICollection<CategoryVM>? Categories { get; set; }
    }
}
