using DevBlog.Service.IServices;
using DevBlog.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevBlog.Web.Pages
{
    public class AccountsModel : PageModel
    {
        private readonly IAccountService _accountService;
        public AccountsModel(IAccountService accountService)
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
