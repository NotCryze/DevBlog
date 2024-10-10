using DevBlog.Domain.IRepositories;
using DevBlog.Shared;
using DevBlog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DevBlog.Domain.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private SQL _sql;
        public BlogPostRepository()
        {
            _sql = new SQL();
        }

        public bool CreateBlogPost(BlogPost blogPost)
        {
            SqlCommand cmd = _sql.ExecuteSP("spCreateBlogPost");
            cmd.Parameters.AddWithValue("@Id", blogPost.Id);
            cmd.Parameters.AddWithValue("@Title", blogPost.Title);
            cmd.Parameters.AddWithValue("@Content", blogPost.Content);
            cmd.Parameters.AddWithValue("@AuthorId", blogPost.Account.Id);
            cmd.Parameters.AddWithValue("@CategoryId", blogPost.Category.Id);
            cmd.Parameters.AddWithValue("@PostType", PostType.BlogPost);
            cmd.Parameters.AddWithValue("@TimeRegistrationId", blogPost.TimeRegistration.Id);

            try
            {
                cmd.Connection.Open();
                int rowsAffeted = cmd.ExecuteNonQuery();
                return rowsAffeted > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return false;
        }

        public BlogPost? GetBlogPost(Guid id)
        {
            SqlCommand cmd = _sql.ExecuteSP("spGetBlogPost");
            cmd.Parameters.AddWithValue("@Id", id);

            try
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BlogPost blogPost = new BlogPost
                        (
                            reader.GetGuid(reader.GetOrdinal("Id")),
                            new Account(
                                reader.GetGuid(reader.GetOrdinal("AuthorId")),
                                reader.GetString(reader.GetOrdinal("AccountFirstName")),
                                reader.GetString(reader.GetOrdinal("AccountLastName")),
                                reader.GetString(reader.GetOrdinal("AccountEmail")),
                                reader.GetString(reader.GetOrdinal("AccountPassword")),
                                reader.GetBoolean(reader.GetOrdinal("AccountIsAdmin")),
                                new TimeRegistration(
                                    reader.GetGuid(reader.GetOrdinal("AccountTimeRegistrationId")),
                                    reader.GetDateTime(reader.GetOrdinal("AccountUpdatedAt")),
                                    reader.GetDateTime(reader.GetOrdinal("AccountCreatedAt"))
                                    )
                                ),
                            reader.GetString(reader.GetOrdinal("Title")),
                            reader.GetString(reader.GetOrdinal("Content")),
                            new Category(
                                reader.GetGuid(reader.GetOrdinal("CategoryId")),
                                reader.GetString(reader.GetOrdinal("CategoryName"))
                                ),
                            new TimeRegistration(
                                reader.GetGuid(reader.GetOrdinal("TimeRegistrationId")),
                                reader.GetDateTime(reader.GetOrdinal("UpdatedAt")),
                                reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                                )
                        );
                        return blogPost;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return null;
        }

        public List<BlogPost> GetBlogPosts()
        {
            SqlCommand cmd = _sql.ExecuteSP("spGetBlogPosts");

            List<BlogPost> blogPosts = new List<BlogPost>();

            try
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BlogPost blogPost = new BlogPost
                        (
                            reader.GetGuid(reader.GetOrdinal("Id")),
                            new Account(
                                reader.GetGuid(reader.GetOrdinal("AuthorId")),
                                reader.GetString(reader.GetOrdinal("AccountFirstName")),
                                reader.GetString(reader.GetOrdinal("AccountLastName")),
                                reader.GetString(reader.GetOrdinal("AccountEmail")),
                                reader.GetString(reader.GetOrdinal("AccountPassword")),
                                reader.GetBoolean(reader.GetOrdinal("AccountIsAdmin")),
                                new TimeRegistration(
                                    reader.GetGuid(reader.GetOrdinal("AccountTimeRegistrationId")),
                                    reader.GetDateTime(reader.GetOrdinal("AccountUpdatedAt")),
                                    reader.GetDateTime(reader.GetOrdinal("AccountCreatedAt"))
                                    )
                                ),
                            reader.GetString(reader.GetOrdinal("Title")),
                            reader.GetString(reader.GetOrdinal("Content")),
                            new Category(
                                reader.GetGuid(reader.GetOrdinal("CategoryId")),
                                reader.GetString(reader.GetOrdinal("CategoryName"))
                                ),
                            new TimeRegistration(
                                reader.GetGuid(reader.GetOrdinal("TimeRegistrationId")),
                                reader.GetDateTime(reader.GetOrdinal("UpdatedAt")),
                                reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                                )
                        );
                        blogPosts.Add(blogPost);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return blogPosts;
        }

        public List<BlogPost> GetBlogPostsByAccount(Guid id)
        {
            SqlCommand cmd = _sql.ExecuteSP("spGetBlogPostsByAccountId");
            cmd.Parameters.AddWithValue("@Id", id);

            List<BlogPost> blogPosts = new List<BlogPost>();

            try
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BlogPost blogPost = new BlogPost
                        (
                            reader.GetGuid(reader.GetOrdinal("Id")),
                            new Account(
                                reader.GetGuid(reader.GetOrdinal("AuthorId")),
                                reader.GetString(reader.GetOrdinal("AccountFirstName")),
                                reader.GetString(reader.GetOrdinal("AccountLastName")),
                                reader.GetString(reader.GetOrdinal("AccountEmail")),
                                reader.GetString(reader.GetOrdinal("AccountPassword")),
                                reader.GetBoolean(reader.GetOrdinal("AccountIsAdmin")),
                                new TimeRegistration(
                                    reader.GetGuid(reader.GetOrdinal("AccountTimeRegistrationId")),
                                    reader.GetDateTime(reader.GetOrdinal("AccountUpdatedAt")),
                                    reader.GetDateTime(reader.GetOrdinal("AccountCreatedAt"))
                                    )
                                ),
                            reader.GetString(reader.GetOrdinal("Title")),
                            reader.GetString(reader.GetOrdinal("Content")),
                            new Category(
                                reader.GetGuid(reader.GetOrdinal("CategoryId")),
                                reader.GetString(reader.GetOrdinal("CategoryName"))
                                ),
                            new TimeRegistration(
                                reader.GetGuid(reader.GetOrdinal("TimeRegistrationId")),
                                reader.GetDateTime(reader.GetOrdinal("UpdatedAt")),
                                reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                                )
                        );
                        blogPosts.Add(blogPost);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return blogPosts;
        }

        public bool DeleteBlogPost(Guid id)
        {
            SqlCommand cmd = _sql.Execute($"DELETE FROM Post WHERE [Id] = '{id}'");

            try
            {
                cmd.Connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return false;
        }
    }
}
