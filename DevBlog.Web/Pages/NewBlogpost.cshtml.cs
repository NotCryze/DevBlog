using DevBlog.Domain.IRepo;
using DevBlog.Domain.Models;
using DevBlog.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;



namespace DevBlog.Web.Pages
{
    public class NewBlogpostModel : PageModel
    {
        private readonly IAccountRepository _accountService;
        private readonly IPost<BlogPost> _blogpostService;
        private readonly ICategoryRepository _categoryService;
        private readonly ITagRepository _tagService;
        private readonly IWebHostEnvironment _environment;
        public NewBlogpostModel(IAccountRepository accountService, IPost<BlogPost> blogpostService, ICategoryRepository categoryService, ITagRepository tagService, IWebHostEnvironment environment)
        {
            _accountService = accountService;
            _blogpostService = blogpostService;
            _categoryService = categoryService;
            _tagService = tagService;
            _environment = environment;
        }

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Tags { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync()
        {
            List<Category> categories = _categoryService.GetCategories();
            List<Tag> tags = _tagService.GetTags();

            foreach (Category category in categories)
            {
                Categories.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
            }
            foreach (Tag tag in tags)
            {
                Tags.Add(new SelectListItem { Text = tag.Name, Value = tag.Id.ToString() });
            }


            return Page();
        }

        [BindProperty]
        public BlogpostDTO Blogpost { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return await OnGetAsync();
            }

            List<string> fileNames = new List<string>();
            foreach (IFormFile image in Blogpost.Images)
            {
                Guid guid = Guid.NewGuid();
                string fileName = guid.ToString() + "." + image.ContentType.Split('/').Last();
                string filePath = Path.Combine(_environment.ContentRootPath, "wwwroot\\img\\", fileName);
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                fileNames.Add(fileName);
            }

            List<Tag> tags = new List<Tag>();

            foreach (Guid tagId in Blogpost.TagIds)
            {
                Tag? tag = _tagService.GetTag(tagId);
                if(tag != null)
                {
                    tags.Add(tag);
                }
            }

            Account? account = _accountService.GetAccount(((AccountDTO)HttpContext.Items["User"]).Id);
            Category? category = _categoryService.GetCategory(Blogpost.CategoryId);

            BlogPost newPost = new BlogPost(account, Blogpost.Title, Blogpost.Content, fileNames, category, tags);
            _blogpostService.CreatePost(newPost);

            return RedirectToPage("Blogpost", new { id = newPost.Id });
        }
    }
}
