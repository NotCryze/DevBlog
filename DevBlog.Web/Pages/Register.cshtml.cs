using DevBlog.Service.IServices;
using DevBlog.Shared.Models;
using DevBlog.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevBlog.Web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IAccountService _accountService;
        public RegisterModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RegisterDTO Register { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_accountService.GetAccountByEmail(Register.Email) != null)
            {
                ModelState.AddModelError("Register.Email", "Email already exists");
            }
            else
            {
                if (_accountService.CreateAccount(Register.FirstName, Register.LastName, Register.Email, Register.Password) != null)
                {
                    return RedirectToPage("/Login");
                }
            }
            return Page();
        }
    }
}
