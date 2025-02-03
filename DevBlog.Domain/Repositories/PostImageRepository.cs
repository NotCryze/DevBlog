using DevBlog.Domain.IRepositories;
using DevBlog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DevBlog.Domain.Repositories
{
    public class PostImageRepository : IPostImageRepository
    {
        private readonly SQL _sql;
        public PostImageRepository()
        {
            _sql = new SQL();
        }

        public bool CreatePostImage(PostImage postImage, Guid postId)
        {
            SqlCommand cmd = _sql.ExecuteSP("spCreatePostImage");
            cmd.Parameters.AddWithValue("@Id", postImage.Id);
            cmd.Parameters.AddWithValue("@Name", postImage.Name);
            cmd.Parameters.AddWithValue("@PostId", postId);

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

        public List<PostImage> GetPostImagesByPost(Guid id)
        {
            SqlCommand cmd = _sql.ExecuteSP("spGetPostImagesByPost");
            cmd.Parameters.AddWithValue("@Id", id);

            List<PostImage> postImages = new List<PostImage>();

            try
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PostImage postImage = new PostImage
                        (
                            reader.GetGuid(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("Name"))
                        );

                        postImages.Add(postImage);
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
            return postImages;
        }

        public bool DeletePostImagesByPost(Guid id)
        {
            SqlCommand cmd = _sql.Execute($"DELETE FROM PostImage WHERE [PostId] = '{id}'");

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
