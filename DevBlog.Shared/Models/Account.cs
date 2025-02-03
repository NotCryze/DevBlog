using System;
using System.Collections.Generic;

namespace DevBlog.Shared.Models
{
    public class Account
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public List<BlogPost> BlogPosts { get; set; }
        public List<PortfolioPost> PortfolioPosts { get; set; }
        public TimeRegistration TimeRegistration { get; set; } = new();

        public Account() { }
        public Account(string firstName, string lastName, string email, string password, bool isAdmin = false)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }
        public Account(Guid id, string firstName, string lastName, string email, string password, bool isAdmin, TimeRegistration timeRegistration)
                : this(firstName, lastName, email, password, isAdmin)
        {
            Id = id;
            TimeRegistration = timeRegistration;
        }
        public Account(Guid id, string firstName, string lastName, string email, string password, bool isAdmin, TimeRegistration timeRegistration, List<BlogPost> blogPosts, List<PortfolioPost> portfolioPosts)
                : this(id, firstName, lastName, email, password, isAdmin, timeRegistration)
        {
            BlogPosts = blogPosts;
            PortfolioPosts = portfolioPosts;
        }
    }
}
