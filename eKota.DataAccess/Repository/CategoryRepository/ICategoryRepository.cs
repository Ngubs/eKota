using eKota.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKota.DataAccess.Repository.CategoryRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public void Update(Category item);
        public void Save();
    }
}
