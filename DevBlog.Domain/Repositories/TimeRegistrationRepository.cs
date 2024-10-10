using DevBlog.Domain.IRepositories;
using DevBlog.Shared.Models;
using System;
using System.Data.SqlClient;

namespace DevBlog.Domain.Repositories
{
    public class TimeRegistrationRepository : ITimeRegistrationRepository
    {
        private SQL _sql;
        public TimeRegistrationRepository()
        {
            _sql = new SQL();
        }

        public bool CreateTimeRegistration(TimeRegistration timeRegistration)
        {
            SqlCommand cmd = _sql.ExecuteSP("spCreateTimeRegistration");
            cmd.Parameters.AddWithValue("@Id", timeRegistration.Id);
            cmd.Parameters.AddWithValue("@UpdatedAt", timeRegistration.UpdatedAt);
            cmd.Parameters.AddWithValue("@CreatedAt", timeRegistration.CreatedAt);

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
    }
}
