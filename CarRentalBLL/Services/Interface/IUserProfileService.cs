using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalBLL.ViewModels.UserDocument;

namespace CarRentalBLL.Services.Interface
{
    public interface IUserProfileService
    {
        UserProfileVM GetUserProfileById(string userId);

         Task<bool> SaveEditedProfileAsync(UserProfileVM userProfilevm);

         Task<bool> DeleteUserDocumentAsync(Guid documentId);

    }


}
