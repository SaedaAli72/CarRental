using CarRentalDAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Repositaries
{
    public class ReviewRepo : GenericRepo<Entities.Review>, Interface.IReviewRepo
    {
        public ReviewRepo(AppDBContext context) : base(context)
        {
        }
    }
}
