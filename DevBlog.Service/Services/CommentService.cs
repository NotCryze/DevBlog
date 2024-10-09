using System;
using System.Collections.Generic;
using System.Linq;
using DevBlog.Service.IRepo;
using DevBlog.Shared.Models;

namespace DevBlog.Service.Repo
{
    public class CommentService : ICommentService
    {
        private List<Comment> _comments = [];

        public Comment? CreateComment(Comment comment)
        {
            _comments.Add(comment);
            return comment;
        }

        public Comment? GetComment(Guid id)
        {
            return _comments.FirstOrDefault(c => c.Id == id);
        }

        public List<Comment> GetComments()
        {
            return _comments;
        }

        public List<Comment> GetCommentsByPost(BlogPost post)
        {
            return _comments.FindAll(c => c.BlogPost.Id == post.Id);
        }

        public bool UpdateComment(Comment newComment)
        {
            Comment? comment = GetComment(newComment.Id);

            if (comment != null)
            {
                int index = _comments.IndexOf(comment);
                _comments[index] = comment;
            }
            return false;
        }

        public bool DeleteComment(Guid id)
        {
            Comment? comment = GetComment(id);

            if (comment != null)
            {
                _comments.Remove(comment);
                return true;
            }
            return false;
        }
    }
}
