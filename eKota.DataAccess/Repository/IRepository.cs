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
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T Get(Expression<Func<T, bool>> predicate);
        public void Add(T item);
        public void Remove(T item);
        public void RemoveRange(IEnumerable<T> items);
    }
}
