using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Repositaries
{
    public class UserRepo : GenericRepo<Entities.AppUser>, Interface.IUserRepo
    {
        public UserRepo(Context.AppDBContext context) : base(context)
        {
        }
    
    }
}
