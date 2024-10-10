using DevBlog.Shared.Models;
using System;
using System.Collections.Generic;

namespace DevBlog.Domain.IRepositories
{
    public interface ITagRepository
    {
        bool CreateTag(Tag tag);
        List<Tag> GetTags();
        List<Tag> GetTagsByPost(Guid id);
        Tag? GetTagByName(string name);
    }
}