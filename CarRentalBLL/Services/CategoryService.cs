using CarRentalBLL.Mapping.Category;
using CarRentalBLL.Services.Interface;
using CarRentalBLL.ViewModels.Category;
using CarRentalDAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Services
{
    public class CategoryService : ICaregotyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ICollection<CategoryVM> GetAllCategories(Func<CategoryVM, bool>? func)
        {
            if (func != null)
            {
                return _unitOfWork.categories.GetAll().Select(c => c.ToCategoryVM()).Where(func).ToList();
            }
            return _unitOfWork.categories.GetAll().Select(c => c.ToCategoryVM()).ToList();
        }
    }
}
