using System;
using System.Collections.Generic;
using DevBlog.Domain.Models;

namespace DevBlog.Domain.IRepo
{
    public interface IAccountRepository
    {
        Account? CreateAccount(Account account);
        bool DeleteAccount(Guid id);
        Account? GetAccount(Guid id);
        Account? GetAccountByEmail(string email);
        List<Account> GetAccounts();
        bool UpdateAccount(Account newAccount);
    }
}