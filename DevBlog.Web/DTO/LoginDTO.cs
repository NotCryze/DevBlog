using System.ComponentModel.DataAnnotations;

namespace DevBlog.Web.DTO
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
