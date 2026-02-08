using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalBLL.Mapping.UserProfile;
using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.UserDocument;
using CarRentalDAL.Entities;
using CarRentalDAL.Enums;
using CarRentalDAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace CarRentalBLL.Services
{
    public class UserProfileService : IUserProfileService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;


        public UserProfileService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        public UserProfileVM GetUserProfileById(string userId)
        {

            UserProfileVM myProfile = new UserProfileVM();

            AppUser user = _userManager.Users.Where(u => u.Id == userId).FirstOrDefault()!;
            List<UserDocument> userDocuments = _unitOfWork.userDocuments.GetAll().Where(u => u.AppUserId == userId).ToList();
             myProfile.MapUserAndDocumentsToProfile(user, userDocuments);
            return myProfile;
        }


        public async Task<bool> SaveEditedProfileAsync(UserProfileVM userProfilevm)
        {
            try
            {
                AppUser user = _userManager.Users.FirstOrDefault(u => u.Id == userProfilevm.Id)!;

                user.MapEditedProfileToUser(userProfilevm);

                await _userManager.UpdateAsync(user);




                if(userProfilevm.UploadDocuments != null && userProfilevm.UploadDocuments.Any())
                {
                    string uploadPath = Path.Combine("wwwroot","uploads","users",user.Id);
                    Directory.CreateDirectory(uploadPath);

                    foreach(var file in userProfilevm.UploadDocuments)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string fullPath = Path.Combine(uploadPath, fileName);

                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        var document = new UserDocument
                        {
                            Id = Guid.NewGuid(),
                            AppUserId = user.Id,
                            FilePath = Path.Combine("uploads", "users", user.Id, fileName),
                          

                        };

                        _unitOfWork.userDocuments.Add(document);
                    }
                     _unitOfWork.Save();

                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }




        public async Task<bool> DeleteUserDocumentAsync(Guid documentId)
        {
            try
            {
                var document = _unitOfWork.userDocuments
                    .GetAll()
                    .FirstOrDefault(d => d.Id == documentId);

                if (document == null)
                    return false;

                string fullPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    document.FilePath.TrimStart('/')
                );

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }

                _unitOfWork.userDocuments.Delete(document);
                _unitOfWork.Save();

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
