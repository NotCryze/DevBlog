using System;
using System.Collections.Generic;
using DevBlog.Shared.Models;

namespace DevBlog.Service.IServices
{
    public interface ICategoryService
    {
        Category? CreateCategory(string name);
        bool DeleteCategory(Guid id);
        List<Category> GetCategories();
        Category? GetCategory(Guid id);
        bool UpdateCategory(Category newCategory);
    }
}