using DevBlog.Service.IRepo;
using DevBlog.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevBlog.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPostService<BlogPost> _blogpostService;
        private readonly IPostService<PortfolioPost> _portfoliopostService;
        public IndexModel(IPostService<BlogPost> blogpostService, IPostService<PortfolioPost> portfoliopostService)
        {
            _blogpostService = blogpostService;
            _portfoliopostService = portfoliopostService;
        }

        public List<BlogPost> RecentBlogposts { get; set; }
        public List<PortfolioPost> RecentPortfolioposts { get; set; }
        public void OnGet()
        {
            RecentBlogposts = _blogpostService.GetPosts().OrderByDescending(p => p.TimeRegistration.CreatedAt).Take(4).ToList();
            RecentPortfolioposts = _portfoliopostService.GetPosts().OrderByDescending(p => p.TimeRegistration.CreatedAt).Take(4).ToList();
        }
    }
}
