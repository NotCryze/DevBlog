using System;
using System.Collections.Generic;

namespace DevBlog.Shared.Models
{
    public abstract class Post(Account account, string title, string content, Category category)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Account Account { get; set; } = account;
        public string Title { get; set; } = title;
        public string Content { get; set; } = content;
        public List<PostImage> Images { get; set; } = [];
        public Category Category { get; set; } = category;
        public List<Tag> Tags { get; set; } = [];
        public TimeRegistration TimeRegistration { get; set; } = new();

        public Post(Guid id, Account account, string title, string content, Category category, TimeRegistration timeRegistration) 
            : this(account, title, content, category)
        {
            Id = id;
            TimeRegistration = timeRegistration;
        }

        public Post(Guid id, Account account, string title, string content, Category category, TimeRegistration timeRegistration, List<PostImage> images, List<Tag> tags)
            : this(id, account, title, content, category, timeRegistration)
        {
            Images = images;
            Tags = tags;
        }
    }
}
