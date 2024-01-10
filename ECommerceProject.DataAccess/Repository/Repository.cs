using ECommerceProject.DataAccess.Data;
using ECommerceProject.DataAccess.Repository.IRepository;
using ECommerceProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _db;
        internal DbSet<T> dbSet; //this is used to set the db to generic
        public Repository(ApplicationDBContext dbContext)
        {
            _db = dbContext;
            this.dbSet = _db.Set<T>();
        }
        public Repository()
        {
            
        }
        void IRepository<T>.Add(T entity)
        {
            dbSet.Add(entity);
            _db.SaveChanges();
        }

        void IRepository<T>.Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        void IRepository<T>.DeleteRange(IEnumerable<T> entities) 
        {
            dbSet.RemoveRange(entities);
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        T IRepository<T>.GetValue(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
    }
}
