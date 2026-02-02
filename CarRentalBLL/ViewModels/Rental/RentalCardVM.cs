using CarRentalDAL.Entities;
using CarRentalDAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.ViewModels.Rental
{
    public class RentalCardVM
    {
        public Guid Id { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ActualDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public RentalStatus Status { get; set; } //enum

        #region CustomerUser
        public string CustomerUserId { get; set; }
        //public AppUser CustomerUser { get; set; }
        #endregion

        #region OwnerUser
        public string OwnerUserId { get; set; }
        //public AppUser OwnerUser { get; set; }
        #endregion

        #region Car
        //public Guid CarId { get; set; }
        public CarRentalDAL.Entities.Car Car { get; set; }
        #endregion


    }
}
