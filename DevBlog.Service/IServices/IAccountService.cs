using System;
using System.Collections.Generic;
using DevBlog.Shared.Models;

namespace DevBlog.Service.IServices
{
    public interface IAccountService
    {
        Account? CreateAccount(string firstName, string lastName, string email, string password, bool isAdmin = false);
        bool DeleteAccount(Guid id);
        Account? GetAccount(Guid id);
        Account? GetAccountByEmail(string email);
        List<Account> GetAccounts();
        bool UpdateAccount(Account newAccount);
    }
}