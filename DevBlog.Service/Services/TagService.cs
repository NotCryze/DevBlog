using System;
using System.Collections.Generic;
using System.Linq;
using DevBlog.Service.IRepo;
using DevBlog.Shared.Models;

namespace DevBlog.Service.Repo
{
    public class TagService : ITagService
    {
        public TagService()
        {
            CreateTag(new Tag("HTML")); // Hard coded example tag
            CreateTag(new Tag("React")); // Hard coded example tag
            CreateTag(new Tag("Python")); // Hard coded example tag
            CreateTag(new Tag("Docker")); // Hard coded example tag
            CreateTag(new Tag("Unity")); // Hard coded example tag
        }
        private List<Tag> _tags = [];

        public Tag? CreateTag(Tag tag)
        {
            if (CheckTag(tag))
            {
                _tags.Add(tag);
                return tag;
            }
            return null;
        }

        public Tag? GetTag(Guid id)
        {
            return _tags.FirstOrDefault(t => t.Id == id);
        }

        public List<Tag> GetTags()
        {
            return _tags;
        }

        public bool UpdateTag(Tag newTag)
        {
            Tag? tag = GetTag(newTag.Id);

            if (tag != null && CheckTag(newTag))
            {
                int index = _tags.FindIndex(t => t.Id == tag.Id);
                _tags[index] = newTag;
                return true;
            }
            return false;
        }

        public bool DeleteTag(Guid id)
        {
            Tag? tag = GetTag(id);

            if (tag != null)
            {
                _tags.Remove(tag);
                return true;
            }
            return false;
        }

        private bool CheckTag(Tag tag)
        {
            return _tags.FirstOrDefault(c => c.Name == tag.Name) == null;
        }
    }
}
