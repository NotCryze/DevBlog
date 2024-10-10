using DevBlog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Domain.Repositories
{
    public class AccountRepository
    {
        private SQL _sql;
        public AccountRepository()
        {
            _sql = new SQL();
        }

        public bool CreateAccount(Account account)
        {
            SqlCommand cmd = _sql.ExecuteSP("spCreateAccount");
            cmd.Parameters.AddWithValue("@Id", account.Id);
            cmd.Parameters.AddWithValue("@FirstName", account.FirstName);
            cmd.Parameters.AddWithValue("@LastName", account.LastName);
            cmd.Parameters.AddWithValue("@Email", account.Email);
            cmd.Parameters.AddWithValue("@Password", account.Password);
            cmd.Parameters.AddWithValue("@IsAdmin", account.IsAdmin);
            cmd.Parameters.AddWithValue("@TímeRegistrationId", "");

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
