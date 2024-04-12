using eKota.DataAccess.Data;
using eKota.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKota.DataAccess.Repository.CategoryRepository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _appDb;
        public CategoryRepository(AppDbContext appDb) : base(appDb)
        {
            _appDb = appDb;
        }

        public void Save()
        {
            _appDb.SaveChanges();
        }

        public void Update(Category item)
        {
            _appDb.Categories.Update(item);
        }
    }
}
