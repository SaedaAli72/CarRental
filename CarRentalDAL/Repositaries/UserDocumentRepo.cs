using CarRentalDAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Repositaries
{
    public class UserDocumentRepo : GenericRepo<Entities.UserDocument>, Interface.IUserDocumentRepo
    {
        public UserDocumentRepo(AppDBContext context) : base(context)
        {
        }
    }
}
