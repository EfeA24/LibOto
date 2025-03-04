using Entities.Models;
using Services.Contracts;
using Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Category CreateCategory(Category category)
        {
            _unitOfWork.Category.CreateCategory(category);
            _unitOfWork.Save();
            return category;
        }

        public Category DeleteCategory(int id)
        {
            var category = _unitOfWork.Category.GetByCondition(c => c.CategoryId == id, trackChanges: false).SingleOrDefault();
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category not found");
            }

            _unitOfWork.Category.DeleteCategory(category);
            _unitOfWork.Save();
            return category;
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _unitOfWork.Category.GetAllCategories(trackChanges).ToList();
        }

        public Category GetCategoryById(int id, bool trackChanges)
        {
            var category = _unitOfWork.Category.GetByCondition(c => c.CategoryId == id, trackChanges).SingleOrDefault();
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category not found");
            }
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            _unitOfWork.Category.UpdateCategory(category);
            _unitOfWork.Save();
            return category;
        }
    }
}