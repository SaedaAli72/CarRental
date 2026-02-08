using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.UserDocument;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarRentalPL.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserProfileService _userProfileService;
        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }




        public IActionResult GetProfile()
        {
            string LoginUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            UserProfileVM userProfile = _userProfileService.GetUserProfileById(LoginUserId);



            return View("GetProfile", userProfile);
        }

        public IActionResult EditProfile()
        {

            string LoginUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            UserProfileVM userProfile = _userProfileService.GetUserProfileById(LoginUserId);
            


            return View("EditProfile", userProfile);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEdit(UserProfileVM userprofilevm)
        {
            if (!ModelState.IsValid)
            {
                return View("EditProfile", userprofilevm);
            }

            bool result =await _userProfileService.SaveEditedProfileAsync(userprofilevm);

            if (result)
            {
                return RedirectToAction("GetProfile", userprofilevm);
            }
            else
            {
                return View("EditProfile", userprofilevm);

            }



        }

        [HttpPost]
        public async Task<IActionResult> DeleteDocument(Guid documentId)
        {
            await _userProfileService.DeleteUserDocumentAsync(documentId);

            return RedirectToAction("GetProfile");
        }
    }
}
    


