using System;
using System.Collections.Generic;
using DevBlog.Shared.Models;

namespace DevBlog.Service.IRepo
{
    public interface ITagService
    {
        Tag? CreateTag(Tag tag);
        bool DeleteTag(Guid id);
        Tag? GetTag(Guid id);
        List<Tag> GetTags();
        bool UpdateTag(Tag newTag);
    }
}