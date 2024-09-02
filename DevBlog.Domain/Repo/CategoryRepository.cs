using System;
using System.Collections.Generic;
using System.Linq;
using DevBlog.Domain.IRepo;
using DevBlog.Domain.Models;

namespace DevBlog.Domain.Repo
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories = [];

        public Category? CreateCategory(Category category)
        {
            if (CheckCategory(category))
            {
                _categories.Add(category);
                return category;
            }
            return null;
        }

        public Category? GetCategory(Guid id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }

        public List<Category> GetCategories()
        {
            return _categories;
        }

        public bool UpdateCategory(Category newCategory)
        {
            Category? category = GetCategory(newCategory.Id);

            if (category != null && CheckCategory(newCategory))
            {
                int index = _categories.IndexOf(category);
                _categories[index] = newCategory;
                return true;
            }
            return false;
        }

        public bool DeleteCategory(Guid id)
        {
            Category? category = GetCategory(id);

            if (category != null)
            {
                _categories.Remove(category);
                return true;
            }
            return false;
        }

        private bool CheckCategory(Category category)
        {
            return _categories.FirstOrDefault(c => c.Name == category.Name) == null;
        }
    }
}
