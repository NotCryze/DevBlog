using System;

namespace DevBlog.Service.Models
{
    public class Tag
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public Tag(string name)
        {
            Name = name;
        }
        public Tag(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
