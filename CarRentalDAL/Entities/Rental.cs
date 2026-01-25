using CarRentalDAL.Enums;

namespace CarRentalDAL.Entities
{
    public class Rental
    {
        public int Id { get; set; }
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
        public int CarId { get; set; }
        public Car Car { get; set; }
        #endregion

        public ICollection<Payment> Payments { get; set; }
    }
}
