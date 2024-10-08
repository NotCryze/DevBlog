using DevBlog.Service.IRepo;
using System;
using System.Collections.Generic;

namespace DevBlog.Service.Models
{
    public class PortfolioPost : Post
    {
        public PortfolioPost(Account account, string title, string content, List<PostImage> images, Category category, List<Tag> tags)
            : base(account, title, content, images, category, tags)
        { }

        public PortfolioPost(Guid id, Account account, string title, string content, List<PostImage> images, Category category, List<Tag> tags, TimeRegistration timeRegistration)
            : base (id, account, title, content, images, category, tags, timeRegistration)
        { }
    }
}
