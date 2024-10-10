using System;
using System.Collections.Generic;
using System.Linq;
using DevBlog.Domain.IRepositories;
using DevBlog.Service.IServices;
using DevBlog.Shared.Models;
using BC = BCrypt.Net.BCrypt;

namespace DevBlog.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITimeRegistrationRepository _timeRegistrationRepository;
        public AccountService(IAccountRepository accountRepository, ITimeRegistrationRepository timeRegistrationRepository)
        {
            _accountRepository = accountRepository;
            _timeRegistrationRepository = timeRegistrationRepository;
        }
        private List<Account> _accounts = [];

        public Account? CreateAccount(string firstName, string lastName, string email, string password, bool isAdmin = false)
        {
            Account newAccount = new Account(firstName, lastName, email, password, isAdmin);
            if (CheckAccount(newAccount))
            {
                newAccount.Password = BC.EnhancedHashPassword(newAccount.Password);
                _timeRegistrationRepository.CreateTimeRegistration(newAccount.TimeRegistration);
                if (_accountRepository.CreateAccount(newAccount))
                {
                    return newAccount;
                }
            }
            return null;
        }

        public Account? GetAccount(Guid id)
        {
            return _accountRepository.GetAccount(id);
        }

        public Account? GetAccountByEmail(string email)
        {
            return _accountRepository.GetAccountByEmail(email);
        }

        public List<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
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
            return GetAccountByEmail(account.Email) == null;
        }
    }
}
