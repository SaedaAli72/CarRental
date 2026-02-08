using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalBLL.ViewModels.UserDocument;

namespace CarRentalBLL.Mapping.UserProfile
{
    public static class UserProfileMapping
    {
        public static UserProfileVM MapUserAndDocumentsToProfile(this CarRentalBLL.ViewModels.UserDocument.UserProfileVM profile, CarRentalDAL.Entities.AppUser user, List<CarRentalDAL.Entities.UserDocument> userDocuments)
        {
            
            profile.Id = user.Id;
            profile.FirstName = user.FirstName;
            profile.LastName = user.LastName;
            profile.Address = user.Address;
            profile.Email = user.Email;
            profile.Phone = user.PhoneNumber;

            profile.UserDocuments = userDocuments;

            return profile;
        }

        public static CarRentalDAL.Entities.AppUser MapEditedProfileToUser(this CarRentalDAL.Entities.AppUser user, UserProfileVM profile)
        {
            user.FirstName = profile.FirstName;
            user.LastName = profile.LastName;
            user.Address = profile.Address;
            user.Email = profile.Email;
            user.PhoneNumber = profile.Phone;
            return user;
        }


    }
}
