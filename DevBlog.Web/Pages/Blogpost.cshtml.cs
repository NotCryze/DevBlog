using DevBlog.Service.IRepo;
using DevBlog.Service.Models;
using DevBlog.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DevBlog.Web.Pages
{
    public class BlogpostModel : PageModel
    {
        private readonly IPostService<BlogPost> _blogpostService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IWebHostEnvironment _environment;
        public BlogpostModel(IPostService<BlogPost> blogpostService, ICategoryService categoryService, ITagService tagService, IWebHostEnvironment environment)
        {
            _blogpostService = blogpostService;
            _categoryService = categoryService;
            _tagService = tagService;
            _environment = environment;
        }

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Tags { get; set; } = new List<SelectListItem>();

        public BlogPost Blogpost { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            BlogPost? blogpost = _blogpostService.GetPost(id);
            if (blogpost == null)
            {
                return NotFound();
            }

            Blogpost = blogpost;

            List<Category> categories = _categoryService.GetCategories();
            List<Tag> tags = _tagService.GetTags();

            foreach (Category category in categories)
            {
                bool selected = false;
                if (category.Id == blogpost.Category.Id)
                {
                    selected = true;
                }
                Categories.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString(), Selected = selected });
            }
            foreach (Tag tag in tags)
            {
                bool selected = false;
                foreach (Tag postTag in blogpost.Tags)
                {
                    if (tag.Id == postTag.Id)
                    {
                        selected = true;
                    }
                }
                Tags.Add(new SelectListItem { Text = tag.Name, Value = tag.Id.ToString(), Selected = selected });
            }

            return Page();
        }

        public IActionResult OnPostDelete(Guid id)
        {
            BlogPost? postToDelete = _blogpostService.GetPost(id);
            if (postToDelete.Account.Id != ((AccountDTO)HttpContext.Items["User"]).Id)
            {
                return BadRequest();
            }

            _blogpostService.DeletePost(id);

            return RedirectToPage("/Profile", new { id = ((AccountDTO)HttpContext.Items["User"]).Id });
        }

        [BindProperty]
        public BlogpostDTO EditBlogpost { get; set; }
        public async Task<IActionResult> OnPostEdit(Guid id)
        {
            BlogPost? postToEdit = _blogpostService.GetPost(id);

            if (!ModelState.IsValid)
            {
                return await OnGetAsync(id);
            }
            if (postToEdit.Account.Id != ((AccountDTO)HttpContext.Items["User"]).Id)
            {
                return BadRequest();
            }
            else
            {

                List<PostImage> images = new List<PostImage>();
                foreach (IFormFile image in EditBlogpost.Images)
                {
                    Guid guid = Guid.NewGuid();
                    string fileName = guid.ToString() + "." + image.ContentType.Split('/').Last();
                    string filePath = Path.Combine(_environment.ContentRootPath, "wwwroot\\img\\", fileName);
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }
                    images.Add(new PostImage(fileName));
                }

                List<Tag> tags = new List<Tag>();

                foreach (Guid tagId in EditBlogpost.TagIds)
                {
                    Tag? tag = _tagService.GetTag(tagId);
                    if (tag != null)
                    {
                        tags.Add(tag);
                    }
                }

                Category? category = _categoryService.GetCategory(EditBlogpost.CategoryId);

                postToEdit.TimeRegistration.UpdatedAt = DateTime.Now;
                _blogpostService.UpdatePost(new BlogPost(postToEdit.Id, postToEdit.Account, EditBlogpost.Title, EditBlogpost.Content, images.Count > 0 ? images : postToEdit.Images, category, tags, postToEdit.Comments, postToEdit.TimeRegistration));
            }

            return RedirectToPage("/Blogpost", new { id = postToEdit.Id });
        }
    }
}
