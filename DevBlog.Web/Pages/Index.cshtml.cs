using DevBlog.Domain.IRepo;
using DevBlog.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevBlog.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IAccountRepository _accountService;
        public IndexModel(ILogger<IndexModel> logger, IAccountRepository accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public List<Account> Accounts { get; set; }
        public void OnGet()
        {
            Accounts = _accountService.GetAccounts();
        }
    }
}
