using DevBlog.Shared.Models;
using System;
using System.Collections.Generic;

namespace DevBlog.Service.IRepo
{
    public interface IPostService<T> where T : Post
    {
        T? CreatePost(T post);
        T? GetPost(Guid id);
        List<T> GetPosts();
        List<T> GetPostsByAccountId(Guid accountId);
        bool UpdatePost(T newPost);
        bool DeletePost(Guid id);
    }
}