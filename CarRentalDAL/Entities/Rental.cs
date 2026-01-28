using CarRentalDAL.Enums;

namespace CarRentalDAL.Entities
{
    public class Rental
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime RentalDate { get; set; }
        public DateTime? ActualDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public RentalStatus Status { get; set; } //enum

        #region CustomerUser
        public string CustomerUserId { get; set; }
        public AppUser CustomerUser { get; set; }
        #endregion

        #region OwnerUser
        public string OwnerUserId { get; set; }
        public AppUser OwnerUser { get; set; }
        #endregion

        #region Car
        public string CarId { get; set; }
        public Car Car { get; set; }
        #endregion

        public ICollection<Payment> Payments { get; set; }
    }
}
