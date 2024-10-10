using DevBlog.Shared.Models;
using System.Collections.Generic;

namespace DevBlog.Domain.IRepositories
{
    public interface ICategoryRepository
    {
        bool CreateCategory(Category category);
        List<Category> GetCategories();
        Category? GetCategoryByName(string name);
    }
}