using System;
using System.Collections.Generic;
using System.Linq;
using DevBlog.Domain.IRepositories;
using DevBlog.Service.IServices;
using DevBlog.Shared.Models;

namespace DevBlog.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        private List<Category> _categories = [];

        public Category? CreateCategory(string name)
        {
            Category newCategory = new Category(name);
            if (CheckCategory(newCategory))
            {
                _categoryRepository.CreateCategory(newCategory);
                return newCategory;
            }
            return null;
        }

        public Category? GetCategory(Guid id)
        {
            return _categoryRepository.GetCategory(id);
        }

        public List<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
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
            return _categoryRepository.GetCategoryByName(category.Name) == null;
        }
    }
}
