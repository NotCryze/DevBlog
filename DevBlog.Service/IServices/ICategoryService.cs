using System;
using System.Collections.Generic;
using DevBlog.Shared.Models;

namespace DevBlog.Service.IRepo
{
    public interface ICategoryService
    {
        Category? CreateCategory(Category category);
        bool DeleteCategory(Guid id);
        List<Category> GetCategories();
        Category? GetCategory(Guid id);
        bool UpdateCategory(Category newCategory);
    }
}