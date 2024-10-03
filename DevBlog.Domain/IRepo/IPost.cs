using DevBlog.Domain.Models;
using System;
using System.Collections.Generic;

namespace DevBlog.Domain.IRepo
{
    public interface IPost<T> where T : Post
    {
        T? CreatePost(T post);
        T? GetPost(Guid id);
        List<T> GetPosts();
        List<T> GetPostsByAccountId(Guid accountId);
        bool UpdatePost(T newPost);
        bool DeletePost(Guid id);
    }
}