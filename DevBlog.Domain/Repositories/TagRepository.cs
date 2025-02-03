using DevBlog.Domain.IRepositories;
using DevBlog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DevBlog.Domain.Repositories
{
    public class TagRepository : ITagRepository
    {
        private SQL _sql;
        public TagRepository()
        {
            _sql = new SQL();
        }

        public bool CreateTag(Tag tag)
        {
            SqlCommand cmd = _sql.ExecuteSP("spCreateTag");
            cmd.Parameters.AddWithValue("@Id", tag.Id);
            cmd.Parameters.AddWithValue("@Name", tag.Name);

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

        public Tag? GetTag(Guid id)
        {
            SqlCommand cmd = _sql.ExecuteSP("spGetTag");
            cmd.Parameters.AddWithValue("@Id", id);

            try
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tag tag = new Tag
                        (
                            reader.GetGuid(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("Name"))
                        );

                        return tag;
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

        public List<Tag> GetTags()
        {
            SqlCommand cmd = _sql.ExecuteSP("spGetTags");
            List<Tag> tags = new List<Tag>();

            try
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tag category = new Tag
                        (
                            reader.GetGuid(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("Name"))
                        );

                        tags.Add(category);
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

            return tags;
        }

        public List<Tag> GetTagsByPost(Guid id)
        {
            SqlCommand cmd = _sql.ExecuteSP("spGetTagsByPost");
            cmd.Parameters.AddWithValue("@Id", id);

            List<Tag> tags = new List<Tag>();

            try
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tag tag = new Tag
                        (
                            reader.GetGuid(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("Name"))
                        );

                        tags.Add(tag);
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

            return tags;
        }

        public Tag? GetTagByName(string name)
        {
            SqlCommand cmd = _sql.ExecuteSP("spGetTagByName");
            cmd.Parameters.AddWithValue("@Name", name);

            try
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tag tag = new Tag
                        (
                            reader.GetGuid(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("Name"))
                        );

                        return tag;
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

        public bool AddTag(Guid tagId, Guid postId)
        {
            SqlCommand cmd = _sql.ExecuteSP("spAddTag");
            cmd.Parameters.AddWithValue("@TagId", tagId);
            cmd.Parameters.AddWithValue("@PostId", postId);

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

        public bool RemoveTagsByPost(Guid id)
        {
            SqlCommand cmd = _sql.Execute($"DELETE FROM PostTags WHERE [PostId] = '{id}'");

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
