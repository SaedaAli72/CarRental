using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Mapping.Category
{
    public static class CategoryToCategoryVM
    {
        public static ViewModels.Category.CategoryVM ToCategoryVM(this CarRentalDAL.Entities.Category category)
        {
            return new ViewModels.Category.CategoryVM
            {
                Id =  category.Id,
                Name = category.Name
            };
        }
    }
}
