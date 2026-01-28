using CarRentalDAL.Enums;

namespace CarRentalDAL.Entities
{
    public class Car
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Brand { get; set; }
        public int ModelYear { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public int Capacity { get; set; }
        public decimal Rate { get; set; } //to car from all user
        public CarStatus Status { get; set; } //Enum

        #region OwnerUser
        public string OwnerUserId { get; set; }
        public AppUser OwnerUser { get; set; } 
        #endregion

        public ICollection<Rental> Rentals { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<CarImage> CarImages { get; set; }


    }
}
