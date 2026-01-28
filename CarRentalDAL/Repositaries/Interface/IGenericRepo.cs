using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Repositaries.Interface
{
    public interface IGenericRepo<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(string id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Save();

    }
}
