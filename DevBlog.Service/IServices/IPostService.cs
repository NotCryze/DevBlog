using DevBlog.Shared.Models;
using System;
using System.Collections.Generic;

namespace DevBlog.Service.IServices
{
    public interface IPostService<T> where T : Post
    {
        T? CreatePost(Account account, string title, string content, List<PostImage> images, Category category, List<Tag> tags);
        T? GetPost(Guid id);
        List<T> GetPosts();
        List<T> GetPostsByAccountId(Guid accountId);
        bool UpdatePost(T newPost);
        bool DeletePost(Guid id);
    }
}