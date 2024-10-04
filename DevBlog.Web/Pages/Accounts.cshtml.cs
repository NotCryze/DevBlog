using DevBlog.Domain.IRepo;
using DevBlog.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevBlog.Web.Pages
{
    public class AccountsModel : PageModel
    {
        private readonly IAccountRepository _accountService;
        public AccountsModel(IAccountRepository accountService)
        {
            _accountService = accountService;
        }

        public List<Account> Accounts { get; set; }
        public void OnGet(string search)
        {
            Accounts = _accountService.GetAccounts();
            if (!string.IsNullOrWhiteSpace(search))
            {
                Accounts = Accounts.FindAll(a => a.FullName.Contains(search));
            }
        }
    }
}
