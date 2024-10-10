using System;
using System.Collections.Generic;

namespace DevBlog.Shared.Models
{
    public class PortfolioPost : Post
    {
        public PortfolioPost(Account account, string title, string content, Category category)
            : base(account, title, content, category)
        { }

        public PortfolioPost(Guid id, Account account, string title, string content, Category category, TimeRegistration timeRegistration)
            : base (id, account, title, content, category, timeRegistration)
        { }

        public PortfolioPost(Guid id, Account account, string title, string content, Category category, TimeRegistration timeRegistration, List<PostImage> images, List<Tag> tags)
            : base(id, account, title, content, category, timeRegistration)
        { }
    }
}
