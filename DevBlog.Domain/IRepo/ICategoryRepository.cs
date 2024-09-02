using System;
using System.Collections.Generic;
using DevBlog.Domain.Models;

namespace DevBlog.Domain.IRepo
{
    public interface ICategoryRepository
    {
        Category? CreateCategory(Category category);
        bool DeleteCategory(Guid id);
        List<Category> GetCategories();
        Category? GetCategory(Guid id);
        bool UpdateCategory(Category newCategory);
    }
}