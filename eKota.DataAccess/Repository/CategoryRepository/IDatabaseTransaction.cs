using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKota.DataAccess.Repository.CategoryRepository
{
    public interface IDatabaseTransaction
    {
        ICategoryRepository CategoryRepository { get; }
        public void Commit();
    }
}
