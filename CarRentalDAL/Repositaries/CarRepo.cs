using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Repositaries
{
    public class CarRepo : GenericRepo<Entities.Car>, Interface.ICarRepo
    {
        public CarRepo(Context.AppDBContext context) : base(context)
        {
        }
    
    }
}
