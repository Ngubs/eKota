using eKota.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eKota.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _appDb;
        internal DbSet<T> dbSet;

        public Repository(AppDbContext appDb) 
        { 
            _appDb = appDb;
            this.dbSet = _appDb.Set<T>();
        }

        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(predicate);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
           return query.ToList();
        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            dbSet.RemoveRange(items);
        }
    }
}
