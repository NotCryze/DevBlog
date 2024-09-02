using System;
using System.Collections.Generic;
using System.Linq;
using DevBlog.Domain.IRepo;
using DevBlog.Domain.Models;

namespace DevBlog.Domain.Repo
{
    public class BlogPostRepository : IPost<BlogPost>
    {
        private List<BlogPost> _posts = [];

        public BlogPost? CreatePost(BlogPost post)
        {
            _posts.Add(post);
            return post;
        }

        public BlogPost? GetPost(Guid id)
        {
            return _posts.FirstOrDefault(p => p.Id == id);
        }

        public List<BlogPost> GetPosts()
        {
            return _posts;
        }

        public List<BlogPost> GetPostsByCategory(Category category)
        {
            return _posts.FindAll(p => p.Category.Id == category.Id);
        }

        public bool UpdatePost(BlogPost newPost)
        {
            BlogPost? post = GetPost(newPost.Id);

            if (post != null)
            {
                int index = _posts.IndexOf(post);
                _posts[index] = newPost;
                return true;
            }
            return false;
        }

        public bool DeletePost(Guid id)
        {
            BlogPost? post = GetPost(id);

            if (post != null)
            {
                _posts.Remove(post);
                return true;
            }
            return false;
        }
    }
}
