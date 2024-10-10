using DevBlog.Shared.Models;

namespace DevBlog.Domain.IRepositories
{
    public interface ITimeRegistrationRepository
    {
        bool CreateTimeRegistration(TimeRegistration timeRegistration);
    }
}