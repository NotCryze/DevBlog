using System;

namespace DevBlog.Domain.Models
{
    public class Tag
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateTime CreatedAt { get; } = DateTime.Now;


        public Tag(string name)
        {
            Name = name;
        }
        public Tag(Guid id, string name, DateTime createdAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
        }
    }
}
