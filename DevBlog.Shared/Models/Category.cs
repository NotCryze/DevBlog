using System;
using System.Collections.Generic;

namespace DevBlog.Shared.Models
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<Post> Posts { get; set; } = [];
        public string Name { get; set; }

        public Category()
        {
                
        }

        public Category(string name)
        {
            Name = name;
        }

        public Category(Guid id, string name)
            : this(name)
        {
            Id = id;

        }

        public Category(Guid id, string name, List<Post> posts)
            : this (id, name)
        {
            Posts = posts;
        }

    }
}
