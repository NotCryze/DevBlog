using DevBlog.Domain.IRepo;
using System;
using System.Collections.Generic;

namespace DevBlog.Domain.Models
{
    public class PortfolioPost : Post, IPostable
    {
        public PortfolioPost(Account account, string title, string content, List<string> images, Category category, List<Tag> tags)
            : base(account, title, content, images, category, tags)
        { }

        public PortfolioPost(Guid id, Account account, string title, string content, List<string> images, Category category, List<Tag> tags, DateTime updatedAt, DateTime createdAt)
            : base (id, account, title, content, images, category, tags, updatedAt, createdAt)
        { }
    }
}
