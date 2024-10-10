using System;
using System.Collections.Generic;
using DevBlog.Shared.Models;

namespace DevBlog.Service.IServices
{
    public interface ITagService
    {
        Tag? CreateTag(string name);
        bool DeleteTag(Guid id);
        Tag? GetTag(Guid id);
        List<Tag> GetTags();
        bool UpdateTag(Tag newTag);
    }
}