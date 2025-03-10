﻿using System;
using System.Collections.Generic;
using System.Linq;
using DevBlog.Service.IServices;
using DevBlog.Shared.Models;

namespace DevBlog.Service.Services
{
    public class PortfolioPostService : IPostService<PortfolioPost>
    {
        private List<PortfolioPost> _posts = [];

        public PortfolioPost? CreatePost(Account account, string title, string content, List<PostImage> images, Category category, List<Tag> tags)
        {
            PortfolioPost newPost = new PortfolioPost(account, title, content, category);
            _posts.Add(newPost);
            return newPost;
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
