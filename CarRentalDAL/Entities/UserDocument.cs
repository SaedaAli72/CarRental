using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalDAL.Enums;

namespace CarRentalDAL.Entities
{
    public class UserDocument
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public DocumentType DocumentType { get; set; } 

        #region User
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; } 
        #endregion
    }
}
