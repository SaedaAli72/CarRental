using Microsoft.AspNetCore.Identity;

namespace CarRentalDAL.Entities
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }




        public ICollection<Car> Cars { get; set; } = default!;
        public ICollection<Rental> OwnerRentals { get; set; } = default!;
        public ICollection<Rental> CustomerRentals { get; set; } = default!;

        public ICollection<Payment> Payments { get; set; } = default!;
        public ICollection<Review> Reviews { get; set; } = default!;
        public ICollection<UserDocument> UserDocuments { get; set; } = default!;

    }
}
 