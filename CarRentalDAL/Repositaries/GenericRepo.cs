using CarRentalDAL.Context;
using CarRentalDAL.Repositaries.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Repositaries
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDBContext _context;
        public GenericRepo(AppDBContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(string id)
        {
           return _context.Set<T>().Find(id);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
