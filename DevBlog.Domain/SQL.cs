using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DevBlog.Domain
{
    public class SQL
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DevBlog;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public SqlCommand Execute(string storedProcedure)
        {
            SqlCommand sqlCommand = new SqlCommand(storedProcedure, new SqlConnection(_connectionString));
            sqlCommand.CommandType = CommandType.Text;
            return sqlCommand;
        }

        public SqlCommand ExecuteSP(string storedProcedure)
        {
            SqlCommand sqlCommand = new SqlCommand(storedProcedure, new SqlConnection(_connectionString));
            sqlCommand.CommandType = CommandType.StoredProcedure;
            return sqlCommand;
        }

        public SQL()
        {
            //_connectionString = ConfigurationManager.ConnectionStrings["DevBlogCon"].ConnectionString;
        }

    }
}
