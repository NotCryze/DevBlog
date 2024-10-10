using Microsoft.OpenApi.Attributes;

namespace DevBlog.Shared
{
    public enum PostType : byte
    {
        [Display("BlogPost")]
        BlogPost = 0,

        [Display("ProjectPost")]
        ProjectPost = 1
    }
}
