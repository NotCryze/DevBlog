using DevBlog.Shared.Models;
using System;
using System.Collections.Generic;

namespace DevBlog.Domain.IRepositories
{
    public interface IBlogPostRepository
    {
        bool CreateBlogPost(BlogPost blogPost);
        BlogPost? GetBlogPost(Guid id);
        List<BlogPost> GetBlogPosts();
        List<BlogPost> GetBlogPostsByAccount(Guid id);
        bool DeleteBlogPost(Guid id);
    }
}