using DevBlog.Domain.IRepo;
using DevBlog.Domain.Models;
using DevBlog.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevBlog.Web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IAccountRepository _accountService;
        public RegisterModel(IAccountRepository accountService)
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

            if (_accountService.CreateAccount(new Account(Register.FirstName, Register.LastName, Register.Email, Register.Password)) == null)
            {
                ModelState.AddModelError("Register.Email", "Email already exists");
            }
            else
            {
                return RedirectToPagePermanent("Index");
            }

            return Page();
        }
    }
}
