using System;

namespace DevBlog.Service.Models
{
    public class Comment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public BlogPost BlogPost { get; set; }
        public string Content { get; set; }
        public Account Author { get; set; }
        public TimeRegistration TimeRegistration { get; set; } = new();

        public Comment(BlogPost blogPost, string content, Account author)
        {
            BlogPost = blogPost;
            Content = content;
            Author = author;
        }

        public Comment(Guid id, BlogPost blogPost, string content, Account author, TimeRegistration timeRegistration)
        {
            Id = id;
            BlogPost = blogPost;
            Content = content;
            Author = author;
            TimeRegistration = timeRegistration;
        }
    }
}
