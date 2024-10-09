using DevBlog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DevBlog.Domain.Repositories
{
    public class BlogPostRepository
    {
        private SQL _sql;
        public BlogPostRepository()
        {
            _sql = new SQL();
        }

        public bool CreateBlogPost(BlogPost blogPost)
        {
            SqlCommand cmd = _sql.ExecuteSP("spCreateBlogPost");

            return false;
        }
    }
}
