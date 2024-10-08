using System;

namespace DevBlog.Service.Models
{
    public class TimeRegistration
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; } = DateTime.Now;

        public TimeRegistration()
        {
            
        }
        public TimeRegistration(Guid id, DateTime updatedAt, DateTime createdAt)
        {
            Id = id;
            UpdatedAt = updatedAt;
            CreatedAt = createdAt;
        }
    }
}
