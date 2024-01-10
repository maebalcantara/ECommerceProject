using ECommerceProject.DataAccess.Data;
using ECommerceProject.DataAccess.Repository.IRepository;
using ECommerceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDBContext _dbContext;
        public CategoryRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        void ICategoryRepository.Save()
        {
            _dbContext.SaveChanges();
        }

        void ICategoryRepository.Update(Category category)
        {
            _dbContext.Categories.Update(category);
        }
    }
}
