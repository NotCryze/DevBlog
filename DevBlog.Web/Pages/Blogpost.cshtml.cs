using DevBlog.Domain.IRepo;
using DevBlog.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevBlog.Web.Pages
{
    public class BlogpostModel : PageModel
    {
        private readonly IPost<BlogPost> _blogpostService;
        public BlogpostModel(IPost<BlogPost> blogpostService)
        {
            _blogpostService = blogpostService;
        }

        public BlogPost Blogpost { get; set; }
        public IActionResult OnGet(Guid id)
        {
            BlogPost? blogpost = _blogpostService.GetPost(id);

            if (blogpost == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
