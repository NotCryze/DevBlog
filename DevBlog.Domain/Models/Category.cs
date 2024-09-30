using System;
using System.Collections.Generic;

namespace DevBlog.Domain.Models
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<Post> Posts { get; set; } = [];
        public string Name { get; set; }
        public DateTime CreatedAt { get; } = DateTime.Now;
        public Category(string name)
        {
            Name = name;
        }

        public Category(Guid id, string name, List<Post> posts, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Posts = posts;
            CreatedAt = createdAt;
        }

    }
}
