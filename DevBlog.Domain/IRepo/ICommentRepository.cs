using System;
using System.Collections.Generic;
using DevBlog.Domain.Models;

namespace DevBlog.Domain.IRepo
{
    public interface ICommentRepository
    {
        Comment? CreateComment(Comment comment);
        bool DeleteComment(Guid id);
        Comment? GetComment(Guid id);
        List<Comment> GetComments();
        List<Comment> GetCommentsByPost(BlogPost post);
        bool UpdateComment(Comment newComment);
    }
}