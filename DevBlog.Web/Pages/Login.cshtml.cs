using DevBlog.Domain.IRepo;
using DevBlog.Domain.Models;
using DevBlog.Web.DTO;
using DevBlog.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BC = BCrypt.Net.BCrypt;

namespace DevBlog.Web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountRepository _accountService;
        public LoginModel(IAccountRepository accountService)
        {
            _accountService = accountService;
        }
        public void OnGet()
        {
        }

        [BindProperty]
        public LoginDTO Login { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Account? account = _accountService.GetAccountByEmail(Login.Email);

            if (account != null)
            {
                bool passwordValidated = BC.EnhancedVerify(Login.Password, account.Password);
                if (passwordValidated)
                {
                    HttpContext.Session.SetAccount(new AccountDTO(account.Id, account.FirstName, account.LastName, account.Email, account.IsAdmin));
                    return RedirectToPage("/Index");
                }
                else
                {
                    ModelState.AddModelError("Login", "Email or password is wrong");
                }
            }
            else
            {
                ModelState.AddModelError("Login", "Email or password is wrong");
            }
            return Page();
        }
    }
}
