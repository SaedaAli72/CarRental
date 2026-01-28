using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Repositaries
{
    public class RentalRepo : GenericRepo<Entities.Rental>, Interface.IRentalRepo
    {
        public RentalRepo(Context.AppDBContext context) : base(context)
        {
        }
    
    }
}
