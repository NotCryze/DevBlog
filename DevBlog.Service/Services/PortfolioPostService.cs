using System;
using System.Collections.Generic;
using System.Linq;
using DevBlog.Service.IRepo;
using DevBlog.Shared.Models;

namespace DevBlog.Service.Repo
{
    public class PortfolioPostService : IPostService<PortfolioPost>
    {
        private List<PortfolioPost> _posts = [];

        public PortfolioPost? CreatePost(PortfolioPost post)
        {
            _posts.Add(post);
            return post;
        }

        public PortfolioPost? GetPost(Guid id)
        {
            return _posts.FirstOrDefault(p => p.Id == id);
        }

        public List<PortfolioPost> GetPosts()
        {
            return _posts;
        }

        public List<PortfolioPost> GetPostsByAccountId(Guid accountId)
        {
            return _posts.FindAll(p => p.Account.Id == accountId);
        }

        public bool UpdatePost(PortfolioPost newPost)
        {
            PortfolioPost? post = GetPost(newPost.Id);

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
            PortfolioPost? post = GetPost(id);

            if (post != null)
            {
                _posts.Remove(post);
                return true;
            }
            return false;
        }
    }
}
