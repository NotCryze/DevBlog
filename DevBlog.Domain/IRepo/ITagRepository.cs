using System;
using System.Collections.Generic;
using DevBlog.Domain.Models;

namespace DevBlog.Domain.IRepo
{
    public interface ITagRepository
    {
        Tag? CreateTag(Tag tag);
        bool DeleteTag(Guid id);
        Tag? GetTag(Guid id);
        List<Tag> GetTags();
        bool UpdateTag(Tag newTag);
    }
}