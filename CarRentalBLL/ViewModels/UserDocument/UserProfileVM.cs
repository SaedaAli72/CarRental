using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalDAL.Entities;
using Microsoft.AspNetCore.Http;

namespace CarRentalBLL.ViewModels.UserDocument
{
    public class UserProfileVM
    {
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<CarRentalDAL.Entities.UserDocument>? UserDocuments { get; set; } = default!;

        public List<IFormFile>? UploadDocuments { get; set; } = default!;





    }
}
