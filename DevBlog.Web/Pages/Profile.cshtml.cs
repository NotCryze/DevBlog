using DevBlog.Domain.IRepo;
using DevBlog.Domain.Models;
using DevBlog.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevBlog.Web.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly IAccountRepository _accountService;
        private readonly IPost<BlogPost> _blogpostService;
        private readonly IPost<PortfolioPost> _portfoliopostService;
        public ProfileModel(IAccountRepository accountService, IPost<BlogPost> blogpostService, IPost<PortfolioPost> portfoliopostService)
        {
            _accountService = accountService;
            _blogpostService = blogpostService;
            _portfoliopostService = portfoliopostService;
        }
        public Account? Account { get; set; }
        public bool IsAccountOwner { get; set; } = false;
        public IActionResult OnGet(Guid id)
        {
            Account = _accountService.GetAccount(id);

            if (Account != null)
            {
                Account.Blogposts = _blogpostService.GetPostsByAccountId(Account.Id);
                Account.Portfolioposts = _portfoliopostService.GetPostsByAccountId(Account.Id);
                if (Account.Id == ((AccountDTO)HttpContext.Items["User"]).Id)
                {
                    IsAccountOwner = true;
                }
            }
            else
            {
                return NotFound();
            }

            return Page();
        }
    }
}
