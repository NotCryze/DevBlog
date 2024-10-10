using System;
using System.Collections.Generic;
using DevBlog.Shared.Models;

namespace DevBlog.Service.IServices
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