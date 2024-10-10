using System;
using System.Collections.Generic;
using DevBlog.Domain.IRepositories;
using DevBlog.Service.IServices;
using DevBlog.Shared.Models;

namespace DevBlog.Service.Services
{
    public class BlogPostService : IPostService<BlogPost>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly ITimeRegistrationRepository _timeRegistrationRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IPostImageRepository _postImageRepository;
        public BlogPostService(IBlogPostRepository blogPostRepository, ITimeRegistrationRepository timeRegistrationRepository, ITagRepository tagRepository, IPostImageRepository postImageRepository)
        {
            _blogPostRepository = blogPostRepository;
            _timeRegistrationRepository = timeRegistrationRepository;
            _tagRepository = tagRepository;
            _postImageRepository = postImageRepository;
        }
        private List<BlogPost> _posts = [];

        public BlogPost? CreatePost(Account account, string title, string content, List<PostImage> images, Category category, List<Tag> tags)
        {
            BlogPost newBlogPost = new BlogPost(account, title, content, category);

            _timeRegistrationRepository.CreateTimeRegistration(newBlogPost.TimeRegistration);
            if (_blogPostRepository.CreateBlogPost(newBlogPost))
            {
                foreach (Tag tag in tags)
                {
                    _tagRepository.AddTag(tag.Id, newBlogPost.Id);
                }
                foreach (PostImage image in images)
                {
                    _postImageRepository.CreatePostImage(image, newBlogPost.Id);
                }
                return newBlogPost;
            }

            return null;
        }

        public BlogPost? GetPost(Guid id)
        {
            BlogPost blogPost = _blogPostRepository.GetBlogPost(id);
            blogPost.Tags = _tagRepository.GetTagsByPost(blogPost.Id);
            blogPost.Images = _postImageRepository.GetPostImagesByPost(blogPost.Id);

            return blogPost;
        }

        public List<BlogPost> GetPosts()
        {
            return _blogPostRepository.GetBlogPosts();
        }

        public List<BlogPost> GetPostsByCategory(Category category)
        {
            return _posts.FindAll(p => p.Category.Id == category.Id);
        }

        public List<BlogPost> GetPostsByAccountId(Guid accountId)
        {
            return _blogPostRepository.GetBlogPostsByAccount(accountId);
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
            BlogPost? post = _blogPostRepository.GetBlogPost(id);

            if (post != null)
            {
                _tagRepository.RemoveTagsByPost(post.Id);
                _postImageRepository.DeletePostImagesByPost(post.Id);
                if (_blogPostRepository.DeleteBlogPost(id))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
