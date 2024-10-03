﻿using System;
using System.Collections.Generic;
using System.Linq;
using DevBlog.Domain.IRepo;
using DevBlog.Domain.Models;
using BC = BCrypt.Net.BCrypt;

namespace DevBlog.Domain.Repo
{
    public class AccountRepository : IAccountRepository
    {
        public AccountRepository()
        {
            CreateAccount(new Account("John", "Doe", "admin@example.com", "1234", true)); //Hard coded admin account
        }
        private List<Account> _accounts = [];

        public Account? CreateAccount(Account account)
        {
            account.Password = BC.EnhancedHashPassword(account.Password);
            if (CheckAccount(account))
            {
                _accounts.Add(account);
                return account;
            }
            return null;
        }

        public Account? GetAccount(Guid id)
        {
            return _accounts.FirstOrDefault(a => a.Id == id);
        }

        public Account? GetAccountByEmail(string email)
        {
            return _accounts.FirstOrDefault(a => a.Email == email);
        }

        public List<Account> GetAccounts()
        {
            return _accounts;
        }

        public bool UpdateAccount(Account newAccount)
        {
            Account? account = GetAccount(newAccount.Id);

            if (account != null && CheckAccount(newAccount))
            {
                int index = _accounts.IndexOf(account);
                _accounts[index] = newAccount;
                return true;
            }
            return false;
        }

        public bool DeleteAccount(Guid id)
        {
            Account? account = GetAccount(id);

            if (account != null)
            {
                _accounts.Remove(account);
                return true;
            }
            return false;
        }

        private bool CheckAccount(Account account)
        {
            return _accounts.FirstOrDefault(a => a.Email == account.Email) == null;
        }
    }
}
