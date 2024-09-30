using System;

namespace DevBlog.Domain.Models
{
    public class Comment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public BlogPost BlogPost { get; set; }
        public string Content { get; set; }
        public Account Author { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; } = DateTime.Now;

        public Comment(BlogPost blogPost, string content, Account author)
        {
            BlogPost = blogPost;
            Content = content;
            Author = author;
        }

        public Comment(Guid id, BlogPost blogPost, string content, Account author, DateTime updatedAt, DateTime createdAt)
        {
            Id = id;
            BlogPost = blogPost;
            Content = content;
            Author = author;
            UpdatedAt = updatedAt;
            CreatedAt = createdAt;
        }
    }
}
