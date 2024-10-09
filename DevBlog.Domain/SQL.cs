using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DevBlog.Domain
{
    internal class SQL
    {
        private readonly string _connectionString;

        /// <summary>
        /// Executes SQL Stored Procedures
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <returns>SqlCommand</returns>
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
            _connectionString = ConfigurationManager.ConnectionStrings["DevBlogCon"].ConnectionString;
        }

    }
}
