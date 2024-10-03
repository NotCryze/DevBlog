using DevBlog.Domain.IRepo;
using DevBlog.Domain.Models;
using DevBlog.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevBlog.Web.Pages
{
    public class AccountModel : PageModel
    {
        private readonly IAccountRepository _accountService;
        public AccountModel(IAccountRepository accountService)
        {
            _accountService = accountService;
        }

        public Account Account { get; set; }
        public void OnGet()
        {
            Account = _accountService.GetAccount(((AccountDTO)HttpContext.Items["User"]).Id);
        }
    }
}
