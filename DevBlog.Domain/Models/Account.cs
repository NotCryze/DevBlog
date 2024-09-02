
using System;
using System.Collections.Generic;

namespace DevBlog.Domain.Models
{
    public class Account(string firstName, string lastName, string email, string password, bool isAdmin = false)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;
        public bool IsAdmin { get; set; } = isAdmin;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Post> Posts { get; set; } = [];

        public Account(Guid id, string firstName, string lastName, string email, string password, bool isAdmin, DateTime updatedAt, DateTime createdAt, List<Post> posts) 
            : this(firstName, lastName, email, password, isAdmin)
        {
            Id = id;
            UpdatedAt = updatedAt;
            CreatedAt = createdAt;
            Posts = posts;
        }
    }
}
