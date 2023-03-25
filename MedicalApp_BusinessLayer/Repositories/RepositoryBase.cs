using MedicalApp_BusinessLayer.Contracts;
using MedicalApp_DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Repositories
{
    public abstract class RepositoryBase<T> :IRepositoryBase<T> where T : class
    {
        protected AppDbContext _context;
        
        public RepositoryBase(AppDbContext context)
        {
            _context= context;
        }
        public IQueryable<T> FindAll(bool trackChanges) =>
            trackChanges ?
             _context.Set<T>()
              :
              _context.Set<T>().AsNoTracking();


        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            _context.Set<T>().Where(expression).AsNoTracking()
            : _context.Set<T>().Where(expression).AsTracking(QueryTrackingBehavior.TrackAll);
        public void Create(T entity) => _context.Set<T>().Add(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
    }
}
