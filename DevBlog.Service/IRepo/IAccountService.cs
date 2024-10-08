using System;
using System.Collections.Generic;
using DevBlog.Service.Models;

namespace DevBlog.Service.IRepo
{
    public interface IAccountService
    {
        Account? CreateAccount(Account account);
        bool DeleteAccount(Guid id);
        Account? GetAccount(Guid id);
        Account? GetAccountByEmail(string email);
        List<Account> GetAccounts();
        bool UpdateAccount(Account newAccount);
    }
}