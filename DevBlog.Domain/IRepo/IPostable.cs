using DevBlog.Domain.Models;
using System;
using System.Collections.Generic;

namespace DevBlog.Domain.IRepo
{
    public interface IPostable
    {
        Guid Id { get; set; }
        Account Account { get; set; }
        string Title { get; set; }
        string Content { get; set; }
        List<string> Images { get; set; }
        DateTime UpdatedAt { get; set; }
        DateTime CreatedAt { get; }
        Category Category { get; set; }
        List<Tag> Tags { get; set; }
    }
}