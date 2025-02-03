using DevBlog.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace DevBlog.Web.DTO
{
    public class BlogpostDTO
    {
        [Required]
        [StringLength(32)]
        public string Title { get; set; }

        [Required]
        [StringLength(512)]
        public string Content { get; set; }

        [DataType(DataType.Upload)]
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();

        [Required]
        public Guid CategoryId { get; set; }

        public List<Guid> TagIds { get; set; } = new List<Guid>();
    }
}
