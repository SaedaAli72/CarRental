using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Entities
{
    public class UserDocument
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public string DocumentType { get; set; } //enum

        #region User
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; } 
        #endregion
    }
}
