using DevBlog.Service.IRepo;
using DevBlog.Service.Models;
using DevBlog.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevBlog.Web.Pages
{
    public class AccountModel : PageModel
    {
        private readonly IAccountService _accountService;
        public AccountModel(IAccountService accountService)
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
