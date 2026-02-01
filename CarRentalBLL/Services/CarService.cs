using CarRentalBLL.Mapping.Car;
using CarRentalBLL.Mapping.Category;
using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Car;
using CarRentalDAL.Entities;
using CarRentalDAL.Enums;
using CarRentalDAL.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CarCardVM GetCarById(Guid id)
        {
            return _unitOfWork.cars.GetAll().Include(c => c.Category).Include(c => c.CarImages).FirstOrDefault(c => c.Id == id).ToCarCard();
        }

        ICollection<CarCardVM> ICarService.GetAllCars(Func<Car, bool>? func = null)
        {
            if (func != null)
            {
                return _unitOfWork.cars.GetAll().Include(c => c.Category).Include(c => c.CarImages).Where(func).Select(c => c.ToCarCard()).ToList();
            }
            return _unitOfWork.cars.GetAll().Include(c => c.Category).Include(c => c.CarImages).Select(c => c.ToCarCard()).ToList();
        }
        ICollection<CarCardVM> ICarService.GetAllAvailableCars(Func<Car, bool>? func = null)
        {
            if (func != null)
            {
                return _unitOfWork.cars.GetAll().Where(c => c.Status == CarStatus.Available).Include(c => c.Category).Include(c => c.CarImages).Where(func).Select(c => c.ToCarCard()).ToList();
            }
            return _unitOfWork.cars.GetAll().Where(c => c.Status == CarStatus.Available).Include(c => c.Category).Include(c => c.CarImages).Select(c => c.ToCarCard()).ToList();
        }
        public bool AddCar(CreateCarVM carVM, string OwnerId)
        {
            try
            {
                Car car = carVM.ToCarEntityfromCreate();
                car.OwnerUserId = OwnerId;
                if (carVM.CarImages != null && carVM.CarImages.Any())
                {
                    car.CarImages = new List<CarImage>();

                    foreach (var image in carVM.CarImages)
                    {
                        var imagePath = UploadImage(image); 
                        if (!string.IsNullOrEmpty(imagePath))
                        {
                            car.CarImages.Add(new CarImage
                            {
                                Id = Guid.NewGuid(),
                                ImagePath = imagePath,
                                Description = $"{carVM.Name} Image",
                                CarId = car.Id
                            });
                        }
                    }
                   
                }
                _unitOfWork.cars.Add(car);
                return _unitOfWork.Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/cars");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return "uploads/cars/" + uniqueFileName;
        }


        public bool RemoveCar(Guid carId)
        {
            try
            {
                Car car = _unitOfWork.cars.GetById(c => c.Id == carId);
                List<CarImage> carImages = _unitOfWork.carImages.GetAll().Where(ci => ci.CarId == carId).ToList();
                if (carImages != null && carImages.Any())
                {
                    foreach(var image in carImages)
                    {
                        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", image.ImagePath.TrimStart('/'));
                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                            _unitOfWork.carImages.Delete(image);
                        }
                    }
                }
                _unitOfWork.cars.Delete(car);

                return _unitOfWork.Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateCar(EditCarVM carvm)
        {
            try
            {
                Car car = _unitOfWork.cars.GetAll().Include(c => c.CarImages).FirstOrDefault(c => c.Id == carvm.Id);

                if (car == null)
                    return false;

                carvm.MapToCarEntity(car);

                if (carvm.DeletedImageIds != null && carvm.DeletedImageIds.Any())
                {
                    var imagesToDelete = car.CarImages
                        .Where(i => carvm.DeletedImageIds.Contains(i.Id))
                        .ToList();

                    foreach (var img in imagesToDelete)
                    {
                        DeleteImageFile(img.ImagePath);
                        _unitOfWork.carImages.Delete(img);
                    }
                }

                if (carvm.CarImages != null && carvm.CarImages.Any())

                {
                    car.CarImages ??= new List<CarImage>();
                    foreach (var img in carvm.CarImages)
                    {
                        var newImage = new CarImage
                        {
                            Id = Guid.NewGuid(),
                            ImagePath = UploadImage(img),
                            Description = $"{carvm.Name} Image",
                            CarId = car.Id
                        };

                        car.CarImages.Add(newImage);
                        _unitOfWork.carImages.Add(newImage);
                    }
                }



                _unitOfWork.cars.Update(car);
                return _unitOfWork.Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }




        public EditCarVM GetCarByIdForEdit(Guid carId)
        {
            var car = _unitOfWork.cars.GetAll()
                .Include(c => c.CarImages)
                .Include(c => c.Category)
                .FirstOrDefault(c => c.Id == carId);
            if (car == null)
                return null;
            var carVM = car.MatpToEditCarVm();
            var categories = _unitOfWork.categories.GetAll().ToList(); // ToCategoryVM
            carVM.Categories = categories.Select(cat => cat.ToCategoryVM()).ToList();
            return carVM;
        }


        // for edit
        private void DeleteImageFile(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                return;

            
            var fullPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                imagePath.Replace("/", Path.DirectorySeparatorChar.ToString())
            );

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        public bool ChangeCarStatus(Guid CarId, CarStatus carStatus)
        {
            Car car = _unitOfWork.cars.GetById(c => c.Id == CarId);
            if (car == null)
                return false;
            car.Status = carStatus;
            _unitOfWork.cars.Update(car);
            return _unitOfWork.Save() > 0;
        }

        public CarStatus? GetCarStatus(Guid CarId)
        {
            Car car = _unitOfWork.cars.GetById(c => c.Id == CarId);
            if (car == null)
                return null;
            return car.Status;
        }
    }
}
