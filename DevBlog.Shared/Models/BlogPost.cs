using System;
using System.Collections.Generic;

namespace DevBlog.Shared.Models
{
    public class BlogPost : Post
    {
        public List<Comment> Comments { get; set; } = [];
        public BlogPost(Account account, string title, string content, Category category)
            : base(account, title, content, category)
        { }

        public BlogPost(Guid id, Account account, string title, string content, Category category, TimeRegistration timeRegistration)
            : base(id, account, title, content, category, timeRegistration)
        { }

        public BlogPost(Guid id, Account account, string title, string content, Category category, TimeRegistration timeRegistration, List<PostImage> images, List<Tag> tags, List<Comment> comments)
            : base(id, account, title, content, category, timeRegistration)
        {
            Comments = comments;
        }
    }
}
