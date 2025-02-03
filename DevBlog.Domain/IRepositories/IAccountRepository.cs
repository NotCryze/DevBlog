using DevBlog.Shared.Models;
using System;
using System.Collections.Generic;

namespace DevBlog.Domain.IRepositories
{
    public interface IAccountRepository
    {
        bool CreateAccount(Account account);
        Account? GetAccount(Guid id);
        List<Account> GetAccounts();
        Account? GetAccountByEmail(string email);
    }
}