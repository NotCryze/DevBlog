using System;
using System.Collections.Generic;

namespace DevBlog.Shared.Models
{
    public class BlogPost : Post
    {
        public List<Comment> Comments { get; set; } = [];
        public BlogPost(Account account, string title, string content, List<PostImage> images, Category category, List<Tag> tags)
            : base(account, title, content, images, category, tags)
        { }

        public BlogPost(Guid id, Account account, string title, string content, List<PostImage> images, Category category, List<Tag> tags, List<Comment> comments, TimeRegistration timeRegistration)
            : base(id, account, title, content, images, category, tags, timeRegistration)
        {
            Comments = comments;
        }
    }
}
