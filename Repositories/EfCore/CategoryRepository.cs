using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void CreateCategory(Category category)
        {
            Create(category);
        }

        public void DeleteCategory(Category category)
        {
            Delete(category);
        }

        public IQueryable<Category> GetAllCategories(bool trackChanges)
        {
            return GetAll(trackChanges)
                .OrderBy(c => c.CategoryName);
        }

        public void UpdateCategory(Category category)
        {
            Update(category);
        }
    }
}
