using System;
using System.Collections.Generic;
using System.Linq;
using DevBlog.Domain.IRepo;
using DevBlog.Domain.Models;

namespace DevBlog.Domain.Repo
{
    public class TagRepository : ITagRepository
    {
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
