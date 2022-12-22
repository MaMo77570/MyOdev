using Book.DataAccess.Repository.IRepository;
using Book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj); // it should be _unitOfWork.Category.Update(obj);
        }


        //this is an extra method
        object ICategoryRepository.FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
