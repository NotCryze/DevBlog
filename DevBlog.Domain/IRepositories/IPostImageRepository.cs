using DevBlog.Shared.Models;
using System;
using System.Collections.Generic;

namespace DevBlog.Domain.IRepositories
{
    public interface IPostImageRepository
    {
        bool CreatePostImage(PostImage postImage, Guid postId);
        List<PostImage> GetPostImagesByPost(Guid id);
        bool DeletePostImagesByPost(Guid id);
    }
}