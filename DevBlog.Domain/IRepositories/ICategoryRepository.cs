﻿using DevBlog.Shared.Models;
using System;
using System.Collections.Generic;

namespace DevBlog.Domain.IRepositories
{
    public interface ICategoryRepository
    {
        bool CreateCategory(Category category);
        Category? GetCategory(Guid id);
        List<Category> GetCategories();
        Category? GetCategoryByName(string name);
    }
}