using DevBlog.Domain.IRepositories;
using DevBlog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DevBlog.Domain.Repositories
{
    public class AccountRepository : IAccountRepository
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
            cmd.Parameters.AddWithValue("@TimeRegistrationId", account.TimeRegistration.Id);

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

        public Account? GetAccount(Guid id)
        {
            SqlCommand cmd = _sql.ExecuteSP("spGetAccount");
            cmd.Parameters.AddWithValue("@Id", id);

            try
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Account account = new Account
                        (
                            reader.GetGuid(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("FirstName")),
                            reader.GetString(reader.GetOrdinal("LastName")),
                            reader.GetString(reader.GetOrdinal("Email")),
                            reader.GetString(reader.GetOrdinal("Password")),
                            reader.GetBoolean(reader.GetOrdinal("IsAdmin")),
                            new TimeRegistration
                            (
                                reader.GetGuid(reader.GetOrdinal("TimeRegistrationId")),
                                reader.GetDateTime(reader.GetOrdinal("UpdatedAt")),
                                reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            )
                        );

                        return account;
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

        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();
            SqlCommand cmd = _sql.ExecuteSP("spGetAccounts");

            try
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Account account = new Account
                        (
                            reader.GetGuid(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("FirstName")),
                            reader.GetString(reader.GetOrdinal("LastName")),
                            reader.GetString(reader.GetOrdinal("Email")),
                            reader.GetString(reader.GetOrdinal("Password")),
                            reader.GetBoolean(reader.GetOrdinal("IsAdmin")),
                            new TimeRegistration
                            (
                                reader.GetGuid(reader.GetOrdinal("TimeRegistrationId")),
                                reader.GetDateTime(reader.GetOrdinal("UpdatedAt")),
                                reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            )
                        );

                        accounts.Add(account);
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
            return accounts;
        }

        public Account? GetAccountByEmail(string email)
        {
            SqlCommand cmd = _sql.ExecuteSP("spGetAccountByEmail");
            cmd.Parameters.AddWithValue("@Email", email);

            try
            {
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Account account = new Account
                        (
                            reader.GetGuid(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("FirstName")),
                            reader.GetString(reader.GetOrdinal("LastName")),
                            reader.GetString(reader.GetOrdinal("Email")),
                            reader.GetString(reader.GetOrdinal("Password")),
                            reader.GetBoolean(reader.GetOrdinal("IsAdmin")),
                            new TimeRegistration
                            (
                                reader.GetGuid(reader.GetOrdinal("TimeRegistrationId")),
                                reader.GetDateTime(reader.GetOrdinal("UpdatedAt")),
                                reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            )
                        );

                        return account;
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
