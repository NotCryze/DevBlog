using DevBlog.Domain.IRepositories;
using DevBlog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DevBlog.Domain.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private SQL _sql;
        public CategoryRepository()
        {
            _sql = new SQL();
        }

        public bool CreateCategory(Category category)
        {
            SqlCommand cmd = _sql.ExecuteSP("spCreateCategory");
            cmd.Parameters.AddWithValue("@Id", category.Id);
            cmd.Parameters.AddWithValue("@Name", category.Name);

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

        public Category? GetCategory(Guid id)
        {
            SqlCommand cmd = _sql.ExecuteSP("spGetCategory");
            cmd.Parameters.AddWithValue("@Id", id);

            try
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Category category = new Category
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                        };

                        return category;
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

        public List<Category> GetCategories()
        {
            SqlCommand cmd = _sql.ExecuteSP("spGetCategories");
            List<Category> categories = new List<Category>();

            try
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Category category = new Category
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                        };

                        categories.Add(category);
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

            return categories;
        }

        public Category? GetCategoryByName(string name)
        {
            SqlCommand cmd = _sql.ExecuteSP("spGetCategoryByName");
            cmd.Parameters.AddWithValue("@Name", name);

            try
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Category category = new Category
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                        };

                        return category;
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
    }
}
