using System;
using System.Collections.Generic;
using System.Linq;
using DevBlog.Domain.IRepositories;
using DevBlog.Service.IServices;
using DevBlog.Shared.Models;

namespace DevBlog.Service.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        private List<Tag> _tags = [];

        public Tag? CreateTag(string name)
        {
            Tag newTag = new Tag(name);
            if (CheckTag(newTag))
            {
                if (_tagRepository.CreateTag(newTag))
                {
                    return newTag;
                }
            }
            return null;
        }

        public Tag? GetTag(Guid id)
        {
            return _tags.FirstOrDefault(t => t.Id == id);
        }

        public List<Tag> GetTags()
        {
            return _tagRepository.GetTags();
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
            return _tagRepository.GetTagByName(tag.Name) == null;
        }
    }
}
