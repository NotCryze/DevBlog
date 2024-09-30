using System;
using System.Collections.Generic;

namespace DevBlog.Domain.Models
{
    public abstract class Post
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Account Account { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Images { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; } = DateTime.Now;
        public Category Category { get; set; }
        public List<Tag> Tags { get; set; }

        protected Post(Account account, string title, string content, List<string> images, Category category, List<Tag> tags)
        {
            Account = account;
            Title = title;
            Content = content;
            Images = images;
            Category = category;
            Tags = tags;
       }

        public Post(Guid id, Account account, string title, string content, List<string> images, Category category, List<Tag> tags, DateTime updatedAt, DateTime createdAt) 
            : this(account, title, content, images, category, tags)
        {
            Id = id;
            UpdatedAt = updatedAt;
            CreatedAt = createdAt;
        }
    }
}
