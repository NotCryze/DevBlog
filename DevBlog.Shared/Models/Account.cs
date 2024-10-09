using System;
using System.Collections.Generic;

namespace DevBlog.Shared.Models
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
        public List<BlogPost> Blogposts { get; set; } = [];
        public List<PortfolioPost> Portfolioposts { get; set; } = [];
        public TimeRegistration TimeRegistration { get; set; } = new();

        public Account(Guid id, string firstName, string lastName, string email, string password, bool isAdmin, TimeRegistration timeRegistration, List<BlogPost> blogposts, List<PortfolioPost> portfolioposts) 
            : this(firstName, lastName, email, password, isAdmin)
        {
            Id = id;
            TimeRegistration = timeRegistration;
            Blogposts = blogposts;
            Portfolioposts = portfolioposts;
        }
    }
}
