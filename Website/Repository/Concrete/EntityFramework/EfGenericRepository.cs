using Website.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Remotion.Linq.Clauses;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Website.Repository.Concrete.EntityFramework
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly DbContext _context;
        public EfGenericRepository(WebsiteContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            var deletedEntity =_context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }


        public IQueryable<T> Find(Expression<Func<T, bool>> provide)
        {
            return _context.Set<T>().Where(provide);
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            var updateproduct = _context.Entry(entity);
            updateproduct.State = EntityState.Modified;
            _context.SaveChanges();

        }
    }
}
