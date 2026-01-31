using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Entities
{
    public class Review
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public int Score { get; set; } //to car from one user
        public DateTime Date { get; set; }

        #region CustomerUser
        public string CustomerUserId { get; set; }
        public AppUser CustomerUser { get; set; }
        #endregion

        #region Car
        public Guid CarId { get; set; }
        public Car Car { get; set; } 
        #endregion
    }
}
