using System;
using System.Collections.Generic;

namespace DevBlog.Service.Models
{
    public abstract class Post(Account account, string title, string content, List<PostImage> images, Category category, List<Tag> tags)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Account Account { get; set; } = account;
        public string Title { get; set; } = title;
        public string Content { get; set; } = content;
        public List<PostImage> Images { get; set; } = images;
        public Category Category { get; set; } = category;
        public List<Tag> Tags { get; set; } = tags;
        public TimeRegistration TimeRegistration { get; set; } = new();

        public Post(Guid id, Account account, string title, string content, List<PostImage> images, Category category, List<Tag> tags, TimeRegistration timeRegistration) 
            : this(account, title, content, images, category, tags)
        {
            Id = id;
            TimeRegistration = timeRegistration;
        }
    }
}
