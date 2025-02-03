using System;

namespace DevBlog.Shared.Models
{
    public class PostImage(string name)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = name;

        public PostImage(Guid id, string name)
            : this(name)
        {
            Id = id;
        }
    }
}
