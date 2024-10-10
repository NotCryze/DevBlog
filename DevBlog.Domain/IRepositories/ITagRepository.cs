using DevBlog.Shared.Models;
using System;
using System.Collections.Generic;

namespace DevBlog.Domain.IRepositories
{
    public interface ITagRepository
    {
        bool CreateTag(Tag tag);
        Tag? GetTag(Guid id);
        List<Tag> GetTags();
        List<Tag> GetTagsByPost(Guid id);
        Tag? GetTagByName(string name);
        bool AddTag(Guid tagId, Guid postId);
        bool RemoveTagsByPost(Guid id);
    }
}