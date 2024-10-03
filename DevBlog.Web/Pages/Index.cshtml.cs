using DevBlog.Domain.IRepo;
using DevBlog.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevBlog.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPost<BlogPost> _blogpostService;
        private readonly IPost<PortfolioPost> _portfoliopostService;
        public IndexModel(IPost<BlogPost> blogpostService, IPost<PortfolioPost> portfoliopostService)
        {
            _blogpostService = blogpostService;
            _portfoliopostService = portfoliopostService;
        }

        public List<BlogPost> RecentBlogposts { get; set; }
        public List<PortfolioPost> RecentPortfolioposts { get; set; }
        public void OnGet()
        {
            RecentBlogposts = _blogpostService.GetPosts().OrderByDescending(p => p.CreatedAt).Take(4).ToList();
            RecentPortfolioposts = _portfoliopostService.GetPosts().OrderByDescending(p => p.CreatedAt).Take(4).ToList();
        }
    }
}
