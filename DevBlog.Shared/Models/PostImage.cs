using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Shared.Models
{
    public class PostImage
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }

        public PostImage(string name)
        {
            Name = name;
        }

        public PostImage(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
