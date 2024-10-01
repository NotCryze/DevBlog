using DevBlog.Domain.IRepo;
using System;
using System.Collections.Generic;

namespace DevBlog.Domain.Models
{
    public class BlogPost : Post, IPostable
    {
        public List<Comment> Comments { get; set; } = [];
        public BlogPost(Account account, string title, string content, List<string> images, Category category, List<Tag> tags)
            : base(account, title, content, images, category, tags)
        { }

        public BlogPost(Guid id, Account account, string title, string content, List<string> images, Category category, List<Tag> tags, List<Comment> comments, DateTime updatedAt, DateTime createdAt)
            : base(id, account, title, content, images, category, tags, updatedAt, createdAt)
        {
            Comments = comments;
        }
    }
}
