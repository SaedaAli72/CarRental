using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Repositaries
{
    public class CarImageRepo : GenericRepo<Entities.CarImage>, Interface.ICarImageRepo
    {
        public CarImageRepo(Context.AppDBContext context) : base(context)
        {
        }
    
    }
}
