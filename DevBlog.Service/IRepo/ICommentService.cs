using System;
using System.Collections.Generic;
using DevBlog.Service.Models;

namespace DevBlog.Service.IRepo
{
    public interface ICommentService
    {
        Comment? CreateComment(Comment comment);
        bool DeleteComment(Guid id);
        Comment? GetComment(Guid id);
        List<Comment> GetComments();
        List<Comment> GetCommentsByPost(BlogPost post);
        bool UpdateComment(Comment newComment);
    }
}