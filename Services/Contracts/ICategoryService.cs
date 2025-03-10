﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories(bool trackChanges);
        Category GetCategoryById(int id, bool trackChanges);
        Category CreateCategory (Category category);
        Category UpdateCategory (Category category);
        Category DeleteCategory (int id);
    }
}
