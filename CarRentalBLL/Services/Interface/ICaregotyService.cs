using CarRentalBLL.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Services.Interface
{
    public interface ICaregotyService
    {
        ICollection<CategoryVM> GetAllCategories(Func<CategoryVM, bool>? func);
    }
}
