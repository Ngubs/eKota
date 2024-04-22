using eKota.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKota.DataAccess.Repository.CategoryRepository
{
    public class DatabaseTransaction : IDatabaseTransaction
    {
        private AppDbContext _appDb;
        public ICategoryRepository CategoryRepository { get; private set; }

        public DatabaseTransaction(AppDbContext appDb)
        {
            _appDb = appDb;
            CategoryRepository = new CategoryRepository(_appDb);
        }
        public void Commit()
        {
            _appDb.SaveChanges();
        }
    }
}
